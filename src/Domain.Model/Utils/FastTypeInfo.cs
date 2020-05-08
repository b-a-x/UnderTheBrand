using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace UnderTheBrand.Domain.Model.Utils
{
    public delegate T ObjectActivator<out T>(params object[] args);

    public static class FastTypeInfo<T>
    {
        private static readonly Attribute[] _attributes;

        private static readonly PropertyInfo[] _properties;

        private static readonly MethodInfo[] _methods;

        private static readonly ConstructorInfo[] _constructors;

        private static readonly ConcurrentDictionary<string, ObjectActivator<T>> _activators;

        static FastTypeInfo()
        {
            var type = typeof(T);
            _attributes = type.GetCustomAttributes().ToArray();

            _properties = type
                .GetProperties()
                .Where(x => x.CanRead && x.CanWrite)
                .ToArray();

            _methods = type.GetMethods()
                .Where(x => x.IsPublic && !x.IsAbstract)
                .ToArray();

            _constructors = typeof(T).GetConstructors();
            _activators = new ConcurrentDictionary<string, ObjectActivator<T>>();
        }

        public static PropertyInfo[] PublicProperties => _properties;

        public static MethodInfo[] PublicMethods => _methods;

        public static Attribute[] Attributes => _attributes;

        public static bool HasAttribute<TAttr>()
            where TAttr : Attribute
            => Attributes.Any(x => x.GetType() == typeof(TAttr));

        public static TAttr GetCustomAttribute<TAttr>()
            where TAttr : Attribute
            => (TAttr)_attributes.FirstOrDefault(x => x.GetType() == typeof(TAttr));

        #region Create

        public static T Create(params object[] args)
            => _activators.GetOrAdd(
                    GetSignature(args),
                    GetActivator(GetConstructorInfo(args)))
                .Invoke(args);

        private static string GetSignature(object[] args) 
            => string.Join(",", args.Select(x => x.GetType().ToString()));

        private static ConstructorInfo GetConstructorInfo(object[] args)
        {
            for (var i = 0; i < _constructors.Length; i++)
            {
                ConstructorInfo constructor = _constructors[i];
                ParameterInfo[] ctrParams = constructor.GetParameters();

                if (ctrParams.Length != args.Length) continue;

                var flag = true;
                for (var j = 0; j < args.Length; j++)
                {
                    if (ctrParams[j].ParameterType != args[j].GetType())
                    {
                        flag = false;
                        break;
                    }
                }

                if (!flag) continue;

                return constructor;
            }

            string signature = GetSignature(args);
            throw new InvalidOperationException(
                $"Constructor ({signature}) is not found for {typeof(T)}");
        }

        private static ObjectActivator<T> GetActivator(ConstructorInfo ctor)
        {
            ParameterInfo[] paramsInfo = ctor.GetParameters();
            ParameterExpression param = Expression.Parameter(typeof(object[]), "args");
            Expression[] argsExp = new Expression[paramsInfo.Length];

            for (var i = 0; i < paramsInfo.Length; i++)
            {
                argsExp[i] = Expression.Convert(Expression.ArrayIndex(param, Expression.Constant(i)), paramsInfo[i].ParameterType);
            }

            return (ObjectActivator<T>)Expression.Lambda(typeof(ObjectActivator<T>), body: Expression.New(ctor, argsExp), param).Compile();
        }

        public static Delegate CreateMethod(MethodInfo method)
        {
            if (method == null) throw new ArgumentNullException(nameof(method));
            if (!method.IsStatic) throw new ArgumentException("The provided method must be static.", nameof(method));
            if (method.IsGenericMethod) throw new ArgumentException("The provided method must not be generic.", nameof(method));

            var parameters = method.GetParameters()
                .Select(p => Expression.Parameter(p.ParameterType, p.Name))
                .ToArray();

            var call = Expression.Call(null, method, parameters);
            return Expression.Lambda(call, parameters).Compile();
        }

        #endregion

        public static Func<TObject, TProperty> PropertyGetter<TObject, TProperty>(string propertyName)
        {
            var paramExpression = Expression.Parameter(typeof(TObject), "value");
            var propertyGetterExpression = Expression.Property(paramExpression, propertyName);

            return Expression.Lambda<Func<TObject, TProperty>>(propertyGetterExpression, paramExpression)
                .Compile();
        }

        public static Action<TObject, TProperty> PropertySetter<TObject, TProperty>(string propertyName)
        {
            var paramExpression = Expression.Parameter(typeof(TObject));
            var paramExpression2 = Expression.Parameter(typeof(TProperty), propertyName);
            var propertyGetterExpression = Expression.Property(paramExpression, propertyName);
            var result = Expression.Lambda<Action<TObject, TProperty>>
            (
                Expression.Assign(propertyGetterExpression, paramExpression2), paramExpression, paramExpression2
            ).Compile();

            return result;
        }
    }
}
