namespace HorasExtras.Domain.Exceptions
{
    [Serializable]
    public class HorasExtrasException: System.Exception
    {
        public HorasExtrasException()
        {

        }

        public HorasExtrasException(string mensaje) : base(mensaje)
        {

        }

        public HorasExtrasException(string mensaje, System.Exception innerException): base(mensaje, innerException)
        {

        }
    }
}
