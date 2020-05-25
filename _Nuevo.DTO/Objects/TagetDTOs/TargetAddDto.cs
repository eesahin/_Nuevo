using System;
namespace _Nuevo.DTO.Objects.TagetDTOs
{
    public class TargetAddDto
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public DateTime StartOfPeriod { get; set; }
        public DateTime EndOfPeriod { get; set; }
        public int UserId { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsWork{ get; set; }
   
    }
}
