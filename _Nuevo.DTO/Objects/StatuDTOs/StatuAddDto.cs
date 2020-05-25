using System;
namespace _Nuevo.DTO.Objects.StatuDTOs
{
    public class StatuAddDto
    {
        public int Id { get; set; }
        public int TargetId { get; set; }
        public string Code { get; set; }
        public bool IsSendAnEmail { get; set; }
        public DateTime CheckDateTime { get; set; }
    }
}
