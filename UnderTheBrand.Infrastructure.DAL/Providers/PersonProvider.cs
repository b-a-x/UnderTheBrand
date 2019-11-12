﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UnderTheBrand.Domain.Core.Entities;
using UnderTheBrand.Domain.Interfaces.Providers;
using UnderTheBrand.Infrastructure.DAL.Context;

namespace UnderTheBrand.Infrastructure.DAL.Providers
{
    public class PersonProvider : EntityObjectProvider<Person>, IPersonProvider
    {
        protected PersonProvider() { }

        public PersonProvider(UnderTheBrandContext context) : base(context)
        {
        }

        public async Task<IReadOnlyCollection<Person>> GetList()
        {
            return await _context.Persons
                .OrderBy(p => p.PersonalName.LastName.Value)
                .ThenBy(p => p.PersonalName.FirstName.Value)
                .ToListAsync();
        }
    }
}