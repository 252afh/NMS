using NMS.Models.CustomerViewModels;
using NMS.Models.NumberGroupModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NMS.Models.NumberViewModels
{
    public class CreateNumberModel
    {

        public IEnumerable<Customer> Customer { get; set; }

        public Number Number { get; set; }

        public IEnumerable<Numbergroup> NumberGroup { get; set; }
    }
}
