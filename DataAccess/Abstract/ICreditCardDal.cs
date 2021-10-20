using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICreditCardDal : IEntityRepository<CreditCard>
    {

        CreditCard GetCreditCardByEmail(string email);
    }
}
