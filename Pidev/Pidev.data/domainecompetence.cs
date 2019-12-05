namespace Pidev.data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidevcompetence.domainecompetence")]
    public partial class domainecompetence
    {
        public int id { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        public int? type { get; set; }
    }
}
