namespace Domain.Exceptions
{
    public class AccessDeniedException : Exception
    {
        public AccessDeniedException():base("You don't have access to processing this operation")
        {
            
        }
    }
}
