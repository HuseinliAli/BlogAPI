namespace Domain.Exceptions
{
    public class EmailOrUserWrongException : BusinessException
    {
        public EmailOrUserWrongException():base("Email or password is wrong")
        {
            
        }
    }
}
