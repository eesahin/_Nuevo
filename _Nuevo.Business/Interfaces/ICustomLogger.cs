namespace _Nuevo.Business.Interfaces
{
    public interface ICustomLogger
    {
        void Information(string message);
        void Warning(string message);
        void Debug(string message);
        void Error(string message);
    }
}
