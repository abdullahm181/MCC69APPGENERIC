

using MCC69APP.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MCC69APP.Models
{
    public class JobHistory : IEntity
    {
        public virtual Employees Employees { get; set; }

        [Key]
        [ForeignKey("Employees")]
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual Jobs Jobs { get; set; }
        [ForeignKey("Jobs")]
        public int Job_Id { get; set; }
        public virtual Departments Departments { get; set; }
        [ForeignKey("Departments")]
        public int Department_Id { get; set; }
    }
}
