using System;
using _Nuevo.Entities.Interface;

namespace _Nuevo.Entities.Concrete
{
    public class Period : ITable
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Int64 Second { get; set; }
    }
}
