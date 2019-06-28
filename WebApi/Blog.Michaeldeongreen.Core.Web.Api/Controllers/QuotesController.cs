using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Blog.Michaeldeongreen.Core.Domain;
using Blog.Michaeldeongreen.Core.Common;

namespace Blog.Michaeldeongreen.Core.Web.Api.Controllers
{
    public class QuotesController : Controller
    {
        [Route("api/quote")]
        public Quote Get()
        {
            return BlogContextManager.Quotes.OrderByDescending(q => q.AddedDate).Take(1).SingleOrDefault();
        }
    }
}