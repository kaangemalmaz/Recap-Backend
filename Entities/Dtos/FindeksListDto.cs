using Core.Entities;

namespace Entities.Dtos
{
    public class FindeksListDto : IDto
    {
        public int CstmrId { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; }
        public int CstmrFindeks { get; set; }
    }
}
