using MCC69APP.Repositories.Interface;
using System;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;

using Microsoft.AspNetCore.Http;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace MCC69APP.Base

{
    public class BaseController<TEntity, TRepository> : Controller
           where TEntity : class,IEntity
           where TRepository : IGeneralRepository<TEntity>
    {
        TRepository repository;
        //private readonly IHttpContextAccessor _contextAccessor;

        public BaseController(TRepository repository)
        {
            /*_contextAccessor = new HttpContextAccessor();
            if (_contextAccessor.HttpContext.Session.GetString("Token") == null)
            {
                RedirectToAction("index", "Home").ExecuteResult(this.ControllerContext);
            };*/
            this.repository = repository;
        }
        [HttpGet]
        public JsonResult GetAll()
        {
            var result = repository.Get();  
            return Json(result) ;
        }

        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = repository.Get(id);
            return Json(result);
        }

        [HttpPost]
        public JsonResult Post(TEntity entity)
        {
            var result = repository.Post(entity);
            return Json(result);
        }

        [HttpPut]
        public JsonResult Put(TEntity entity)
        {
            var result = repository.Put(entity);
            return Json(result);
        }

        [HttpDelete]
        public JsonResult DeleteEntity(TEntity entity)
        {
            var result = repository.Delete(entity.Id);
            return Json(result);
        }
        
    }
   
}
