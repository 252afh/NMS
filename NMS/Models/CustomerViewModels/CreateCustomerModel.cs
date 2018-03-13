using NMS.Models.CustomLcrModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NMS.Models.CustomerViewModels
{
    public class CreateCustomerModel
    {

        public Customer Customer { get; set; }

        public IEnumerable<CustomLcr> CustomLcr { get; set; }
    }
}
