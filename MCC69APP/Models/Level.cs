using MCC69APP.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCC69APP.Models
{
    public class Level : IEntity
    {
        public int Id { get; set; }
        public int Value { get; set; }
    }
}
