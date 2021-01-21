using AS_Core.DomainModel;
using AS_Identity;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AS_Management.Helpers
{
    public class AutoMapHelper : Profile
    {
        public AutoMapHelper()
        {
            CreateMap<User, ApplicationUser>();
        }
    }
}
