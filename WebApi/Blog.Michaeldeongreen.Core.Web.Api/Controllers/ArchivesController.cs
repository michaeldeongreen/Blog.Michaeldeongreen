using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Blog.Michaeldeongreen.Core.Services.Interfaces;
using Blog.Michaeldeongreen.Core.Domain;
using Blog.Michaeldeongreen.Core.Common;

namespace Blog.Michaeldeongreen.Core.Web.Api.Controllers
{
    public class ArchivesController : Controller
    {
        private readonly IArchiveService _archiveService;
        public ArchivesController(IArchiveService archiveService)
        {
            _archiveService = archiveService;
        }

        [Route("api/archives")]
        public IList<Archive> Get()
        {
            return _archiveService.Get(BlogContextManager.PostSummaries);
        }
    }
}