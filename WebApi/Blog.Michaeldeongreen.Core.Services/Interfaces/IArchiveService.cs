using Blog.Michaeldeongreen.Core.Domain;
using System.Collections.Generic;

namespace Blog.Michaeldeongreen.Core.Services.Interfaces
{
    public interface IArchiveService
    {
        IList<Archive> Get(IEnumerable<PostSummary> posts);
    }
}
