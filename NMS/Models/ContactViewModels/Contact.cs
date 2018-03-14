// <copyright file="Contact.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

namespace NMS.Models.ContactViewModels
{
    public partial class Contact
    {
        public int Idcontact { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public int FkCustomer { get; set; }
        public int? FkSite { get; set; }
    }
}
