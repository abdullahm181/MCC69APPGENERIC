using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Interface
{
    public interface IJobHistory
    {
        List<JobHistory> Get();

        JobHistory Get(int id);

        int Post(JobHistory jobHistory);

        int Put(int id, JobHistory jobHistory);

        int Delete(int id);
    }
}
