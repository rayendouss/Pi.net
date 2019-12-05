namespace Pidev.data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("templateservices.categories")]
    public partial class categories
    {
        public int id { get; set; }

        public int idtype { get; set; }

        [StringLength(255)]
        public string nomcomp { get; set; }
    }
}
