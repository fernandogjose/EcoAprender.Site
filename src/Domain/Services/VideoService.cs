using System;
using System.Collections.ObjectModel;
using System.Linq;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Helpers;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

using System.Collections.Generic;
using System.IO;

namespace Domain.Services
{
    public class VideoService : BaseService<Video>, IVideoService
    {
        private readonly IVideoRepository _videoRepository;
        public VideoService(IVideoRepository videoRepository)
            : base(videoRepository)
        {
            _videoRepository = videoRepository;
        }


        public override void Validate(Video model)
        {
            if (ValidarTituloDuplicado(model.Id, model.Titulo) > 0)
            {
                throw new CommonException(
                    new Error
                    {
                        Mensagem = "O título já foi cadastrado no sistema."
                    });
            }
        }

        public int ValidarTituloDuplicado(int id, string titulo)
        {
            return _videoRepository.GetAll(x => x.Titulo == titulo && x.Id != id).Count();
        }
    }
}
