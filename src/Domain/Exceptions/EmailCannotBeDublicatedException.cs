namespace Domain.Exceptions
{
    public class EmailCannotBeDublicatedException : BusinessException
    {
        public EmailCannotBeDublicatedException() : base("Email is already exists")
        {
            
        }
    }
}
