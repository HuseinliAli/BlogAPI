namespace Domain.Exceptions;
public class NotFoundByIdException<TKey> : NotFoundException
{
        public NotFoundByIdException(TKey id) : base($"{id} is not exists")
        {

        }
    }
