using Blog.Michaeldeongreen.Core.Domain;

namespace Blog.Michaeldeongreen.Core.Services.Interfaces
{
    public interface IPagingService
    {
        PagedResponse Get(PagedCriteria criteria);

        PagedResponse Search(PagedCriteria criteria);

        PagedResponse GetByCategory(PagedCriteria criteria);

        PagedResponse GetByTag(PagedCriteria criteria);

        PagedResponse GetByMonthAndYear(PagedCriteria criteria);

        PagedResponse GetAlsoOn(PagedCriteria criteria);

        PagedResponse GetPreviews();
    }
}
