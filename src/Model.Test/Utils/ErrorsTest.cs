using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnderTheBrand.Domain.ValueObject.Utils;
using UnderTheBrand.Domain.ValueObject.Values;

namespace UnderTheBrand.Tests.Model.Test.Utils
{
    [TestClass]
    public class ErrorsTest
    {
        [TestMethod]
        public void Error_codes_must_be_unique()
        {
            // arrange
            List<MethodInfo> methods = GetMethods(typeof(Errors));

            // act
            int numberOfUniqueCodes = methods.Select(GetErrorCode)
                .Distinct()
                .Count();

            // assert
            Assert.AreNotEqual(methods.Count, 0);
            Assert.AreNotEqual(numberOfUniqueCodes, 0);
            Assert.AreEqual(methods.Count, numberOfUniqueCodes);
        }

        private List<MethodInfo> GetMethods(Type type)
        {
            var methods = new List<MethodInfo>();
            foreach (MemberInfo memberInfo in type.GetMembers(BindingFlags.Static | BindingFlags.Public))
            {
                if (memberInfo is MethodInfo methodInfo)
                    methods.Add(methodInfo);
                else if (memberInfo is Type _type)
                    methods.AddRange(GetMethods(_type));
            }
            return methods;
        }

        private string GetErrorCode(MethodInfo method)
        {
            object[] parameters = method.GetParameters()
                .Select<ParameterInfo, object>(x =>
                {
                    if (x.ParameterType == typeof(string))
                        return string.Empty;

                    if (x.ParameterType == typeof(int))
                        return 0;

                    throw new Exception();
                })
                .ToArray();

            var error = (Error)method.Invoke(null, parameters);
            return error?.Code;
        }
    }
}
