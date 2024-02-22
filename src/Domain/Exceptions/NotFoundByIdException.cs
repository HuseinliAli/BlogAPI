namespace Domain.Exceptions
{
    public class NotFoundByIdException<TKey> : Exception
    {
        public NotFoundByIdException(TKey id) : base($"{id} is not exists")
        {

        }
    }
  

}
