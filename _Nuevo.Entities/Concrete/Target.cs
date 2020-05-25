using System;
using System.Collections.Generic;
using _Nuevo.Entities.Interface;

namespace _Nuevo.Entities.Concrete
{
    public class Target : ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public DateTime StartOfPeriod { get; set; }
        public DateTime EndOfPeriod { get; set; }
        public int UserId { get; set; }
        public AppUser User { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsWork { get; set; }
        public List<Statu> Status { get; set; }
    }
}
