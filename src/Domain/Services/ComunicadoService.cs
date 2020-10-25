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
    public class ComunicadoService : BaseService<Comunicado>, IComunicadoService
    {
        private readonly IComunicadoRepository _comunicadoRepository;
        public ComunicadoService(IComunicadoRepository comunicadoRepository)
            : base(comunicadoRepository)
        {
            _comunicadoRepository = comunicadoRepository;
        }        
    }
}
