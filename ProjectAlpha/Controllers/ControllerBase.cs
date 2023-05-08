using Microsoft.AspNetCore.Mvc;
using ProjectAlpha.Entities;
using ProjectAlpha.Repository;

namespace ProjectAlpha.Controllers
{
    [ApiController]
    public class ControllerBase<T> : ControllerBase where T : class, IEntity
    {
        private readonly IRepository<T> _repository;

        public ControllerBase(IRepository<T> repository)
        {
            _repository = repository;
        }

        // Implemente os métodos CRUD aqui
    }
}
