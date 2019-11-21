using System.ComponentModel.DataAnnotations;
using UnderTheBrand.Domain.ValueObject.ValidationAttributes;
using UnderTheBrand.Infrastructure.DTO.Base;

namespace UnderTheBrand.Infrastructure.DTO.Entities
{
    public class PersonDto : EntityDto
    {
        [Required, Name]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }
    }
}
