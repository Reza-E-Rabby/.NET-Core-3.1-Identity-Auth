using System;
using System.Collections.Generic;

namespace GamersCommunity.Data.Models
{
    public partial class GcGenreInformation
    {
        public Guid Id { get; set; }
        public string Genre { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }

    }
}
