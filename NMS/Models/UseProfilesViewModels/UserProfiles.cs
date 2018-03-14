using System;
using System.Collections.Generic;

namespace NMS.Models.UserProfilesViewModels
{
    public partial class UserProfiles
    {
        public int Iduser { get; set; }
        public int? Idcustomer { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int? Active { get; set; }
    }
}
