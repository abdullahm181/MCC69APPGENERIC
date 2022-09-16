using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCC69APP.ViewModel
{
    public class RootObject<tEntity>
    {
        public string Result { get; set; }

        public List<tEntity> Data { get; set; }
        
    }
}
