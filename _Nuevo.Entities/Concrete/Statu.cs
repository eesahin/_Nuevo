using System;
using _Nuevo.Entities.Interface;

namespace _Nuevo.Entities.Concrete
{
    public class Statu : ITable
    {
        public int Id { get; set; }
        public int TargetId { get; set; }
        public Target Target { get; set; }
        public string Code { get; set; }
        public DateTime CheckDateTime { get; set; }
        public bool IsSendAnEmail { get; set; }
    }
}
