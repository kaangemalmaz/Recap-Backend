using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapContext>, ICustomerDal
    {
        public FindeksListDto GetFindeksInfo(string email)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from i in context.Customers
                             join k in context.Users on i.UserId equals k.Id
                             where k.Email == email
                             select new FindeksListDto
                             {
                                 CompanyName = i.CompanyName,
                                 CstmrFindeks = i.CstmrFindeks,
                                 CstmrId = i.Id,
                                 UserId = i.UserId
                             };

                return result.FirstOrDefault();
            }

        }
    }
}
