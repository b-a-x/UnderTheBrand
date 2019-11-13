using System.ComponentModel.DataAnnotations;
using UnderTheBrand.Infrastructure.DTO.Base;
using UnderTheBrand.Infrastructure.DTO.ValidationAttributes;

namespace UnderTheBrand.Infrastructure.DTO.Entities
{
    public class PersonDTO : EntityDTO
    {
        [Required, Name]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }
    }
}
