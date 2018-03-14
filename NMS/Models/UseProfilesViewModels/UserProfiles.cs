// <copyright file="UserProfiles.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

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
