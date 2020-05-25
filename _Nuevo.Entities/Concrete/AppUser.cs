using System.Collections.Generic;
using _Nuevo.Entities.Interface;
using Microsoft.AspNetCore.Identity;

namespace _Nuevo.Entities.Concrete
{
    public class AppUser : IdentityUser<int>,ITable
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Target> Targets { get; set; }
    }
}
