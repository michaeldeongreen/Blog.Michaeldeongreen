using Microsoft.AspNetCore.Mvc;
using Blog.Michaeldeongreen.Core.Services.Interfaces;
using Blog.Michaeldeongreen.Core.Common.Interfaces;
using Blog.Michaeldeongreen.Core.Domain;
using Blog.Michaeldeongreen.Core.Common;

namespace Blog.Michaeldeongreen.Core.Web.Api.Controllers
{
    public class SearchController : Controller
    {
        private readonly IPagingService _pagingService;
        private readonly IConfigurationManagerWrapper _configurationManagerWrapper;
        private readonly int _pageSize;

        public SearchController(IPagingService pagingService,
            IConfigurationManagerWrapper configurationManagerWrapper)
        {
            _pagingService = pagingService;
            _configurationManagerWrapper = configurationManagerWrapper;
            _pageSize = _configurationManagerWrapper.AppSettings.Value.PageSize;
        }

        [Route("api/search/{criteria}/page/{pagenumber}")]
        public PagedResponse Get(string criteria, int pageNumber)
        {
            return _pagingService.Search(new PagedCriteria() { PageNumber = pageNumber, PageSize = _pageSize, Posts = BlogContextManager.PostSummaries, SearchCriteria = criteria, IsActive = true });
        }
    }
}