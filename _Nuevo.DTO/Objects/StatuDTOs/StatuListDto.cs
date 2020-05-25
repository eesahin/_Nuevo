using System;
using _Nuevo.Entities.Concrete;

namespace _Nuevo.DTO.Objects.StatuDTOs
{
    public class StatuListDto
    {
        public int Id { get; set; }
        public Target Target { get; set; }
        public string Code { get; set; }
        public bool IsSendAnEmail { get; set; }
        public DateTime CheckDateTime { get; set; }
    }
}
