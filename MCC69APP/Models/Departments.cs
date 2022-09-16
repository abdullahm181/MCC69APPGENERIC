

using MCC69APP.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MCC69APP.Models
{
    public class Departments : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Locations Locations { get; set; }
        [ForeignKey("Locations")]
        public int Location_Id { get; set; }
    }
}
