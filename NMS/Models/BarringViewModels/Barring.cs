// <copyright file="Barring.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

namespace NMS.Models.BarringViewModels
{
    /// <summary>
    /// The model for <see cref="Barring"/>
    /// </summary>
    public partial class Barring
    {
        /// <summary>
        /// Gets or sets id of <see cref="Barring"/>
        /// </summary>
        public int Idbarring { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="Barring"/> <see cref="CodeViewModels.Code"/>
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets a normalised <see cref="CodeViewModels.Code"/>
        /// </summary>
        public string NormalisedCode { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="Barring"/> description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="Barring"/> status
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="Barring"/> linked <see cref="CustomerViewModels.Customer"/>
        /// </summary>
        public int? FkCustomer { get; set; }
    }
}
