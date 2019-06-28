using Microsoft.Extensions.Options;

namespace Blog.Michaeldeongreen.Core.Common.Interfaces
{
    public interface IConfigurationManagerWrapper
    {
        IOptions<AppSettings> AppSettings { get; }
    }
}
