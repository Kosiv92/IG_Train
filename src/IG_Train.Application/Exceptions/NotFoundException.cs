namespace IG_Train.Application.Exceptions
{
    public class NotFoundException : Exception
    {        
        public NotFoundException() { }

        public NotFoundException(string name, object key)
            : base($"Entity \"{name}\" with ID:{key} not found).")
        { }
    }
}
