namespace Pidev.data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidevcompetence.employecompetence")]
    public partial class employecompetence
    {
        public int id { get; set; }

        public int? competence_id { get; set; }

        public int? employe_id { get; set; }

        public virtual competence competence { get; set; }

        public virtual employe employe { get; set; }
    }
}
