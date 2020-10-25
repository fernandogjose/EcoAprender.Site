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
    public class BlogService : BaseService<Blog>, IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        public BlogService(IBlogRepository blogRepository)
            : base(blogRepository)
        {
            _blogRepository = blogRepository;
        }


        public override void Validate(Blog model)
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
            return _blogRepository.GetAll(x => x.Titulo == titulo && x.Id != id).Count();
        }
    }
}
