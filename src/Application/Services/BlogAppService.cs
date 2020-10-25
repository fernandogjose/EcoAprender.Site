using Domain.Interfaces.Application;
using Domain.Entities;
using Domain.Interfaces.Services;

using System.Collections.Generic;
using System.IO;

namespace Application.Services
{
    public class BlogAppService : BaseAppService<Blog>, IBlogAppService
    {
        private readonly IBlogService _blogService;

        public BlogAppService(IBlogService blogService)
            : base(blogService)
        {
            _blogService = blogService;
        }
    }
}
