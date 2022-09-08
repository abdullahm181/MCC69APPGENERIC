using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Interface
{
    public interface IRepository<ObjectName> where ObjectName : class, IEntity
    {
        List<ObjectName> Get();

        ObjectName Get(int id);

        int Post(ObjectName objectName);

        int Put(int id, ObjectName objectName);

        int Delete(int id);
    }
}
