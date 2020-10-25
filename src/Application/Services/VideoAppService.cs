using Domain.Interfaces.Application;
using Domain.Entities;
using Domain.Interfaces.Services;

using System.Collections.Generic;
using System.IO;

namespace Application.Services
{
    public class VideoAppService : BaseAppService<Video>, IVideoAppService
    {
        private readonly IVideoService _videoService;

        public VideoAppService(IVideoService videoService)
            : base(videoService)
        {
            _videoService = videoService;
        }
    }
}
