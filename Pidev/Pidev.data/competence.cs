namespace Pidev.data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("mvcconsumewebapi.competence")]
    public partial class competence
    {
        public int id { get; set; }

        [StringLength(255)]
        public string categorie { get; set; }

        [StringLength(255)]
        public string nom { get; set; }
    }
}
