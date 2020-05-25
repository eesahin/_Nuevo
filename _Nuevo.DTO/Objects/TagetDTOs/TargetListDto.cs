using System;
using System.Collections.Generic;
using _Nuevo.Entities.Concrete;

namespace _Nuevo.DTO.Objects.TagetDTOs
{
    public class TargetListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartOfPeriod { get; set; }
        public DateTime EndOfPeriod { get; set; }
        public string Url { get; set; }
        public AppUser User { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsWork { get; set; }
        public List<Statu> Status { get; set; }
    }
}
