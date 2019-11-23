using System.ComponentModel.DataAnnotations;
using UnderTheBrand.Domain.ValueObject.ValidationAttributes;
using UnderTheBrand.Infrastructure.ViewModel.Base;

namespace UnderTheBrand.Infrastructure.ViewModel.Entities
{
    public class PersonVM : EntityVM
    {
        [Required, Name]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }
    }
}
