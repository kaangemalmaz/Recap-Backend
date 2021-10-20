using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCreditCardDal : EfEntityRepositoryBase<CreditCard, ReCapContext>, ICreditCardDal
    {
        public CreditCard GetCreditCardByEmail(string email)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from i in context.CreditCards
                             join k in context.Users on i.UserId equals k.Id
                             where k.Email == email
                             select new CreditCard
                             {
                                 CardName = i.CardName,
                                 CardNumber = i.CardNumber,
                                 CVV = i.CVV,
                                 ExpireDate = i.ExpireDate,
                                 Id = i.Id,
                                 UserId = i.UserId
                             };

                return result.FirstOrDefault();

            };
        }
    }
}
