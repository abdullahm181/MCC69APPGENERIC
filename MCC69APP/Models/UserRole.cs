
using MCC69APP.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MCC69APP.Models
{
    public class UserRole : IEntity
    {
        [Key]
        public int Id { get; set; }

        public virtual User User { get; set; }
        
        [Required]
        [ForeignKey("User")]
        public int User_Id{ get; set; }
        public virtual Role Role{ get; set; }

        [Required]
        [ForeignKey("Role")]
        public int Role_Id { get; set; }
    }
}
