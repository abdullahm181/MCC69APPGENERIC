using MCC69APP.Repositories.Interface;
using System;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;

namespace MCC69APP.Base

{
    public class BaseController<TEntity, TRepository> : Controller
           where TEntity : class,IEntity
           where TRepository : IGeneralRepository<TEntity>
    {
        TRepository repository;

        public BaseController(TRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public IEnumerable<TEntity> Get()
        {
            var result = repository.Get();
            return result;
        }

        [HttpGet]
        public TEntity Get(int id)
        {
            var result = repository.Get(id);
            return result;
        }

        [HttpPost]
        public HttpStatusCode Post(TEntity entity)
        {
            var result = repository.Post(entity);
            return result;
        }

        [HttpPut]
        public HttpStatusCode Put(TEntity entity)
        {
            var result = repository.Put(entity);
            return result;
        }

        [HttpDelete]
        public HttpStatusCode DeleteEntity(TEntity entity)
        {
            var result = repository.Delete(entity.Id);
            return result;
        }
    }
}
