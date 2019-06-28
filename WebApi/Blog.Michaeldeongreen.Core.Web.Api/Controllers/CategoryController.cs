using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Blog.Michaeldeongreen.Core.Domain;
using Blog.Michaeldeongreen.Core.Common;

namespace Blog.Michaeldeongreen.Core.Web.Api.Controllers
{
    public class CategoryController : Controller
    {
        [Route("api/categories")]
        public IEnumerable<Category> Get()
        {
            return BlogContextManager.Categories.OrderBy(c => c.Name);
        }
    }
}