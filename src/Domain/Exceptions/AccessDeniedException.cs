namespace Domain.Exceptions
{
    public class AccessDeniedException : BadRequestException
    {
        public AccessDeniedException():base("You don't have access to processing this operation")
        {
            
        }
    }

    public class BadRequestException : Exception {
        public BadRequestException(string message):base(message)
        {
            
        }
    }

}
