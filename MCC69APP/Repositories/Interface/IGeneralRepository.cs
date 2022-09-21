using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MCC69APP.Repositories.Interface
{
    public interface IGeneralRepository<Entity>
        where Entity : class,IEntity
    {
        public IEnumerable<Entity> Get();
        public Entity Get(int? id);
        public HttpStatusCode Post(Entity entity);
        public HttpStatusCode Put(Entity entity);
        public HttpStatusCode Delete(int id);
    }
}
