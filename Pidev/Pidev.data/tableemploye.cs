namespace Pidev.data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("templateservices.tableemploye")]
    public partial class tableemploye
    {
        public int id { get; set; }

        public int cin { get; set; }

        [StringLength(255)]
        public string niveaudesktops { get; set; }

        [StringLength(255)]
        public string niveaulangues { get; set; }

        [StringLength(255)]
        public string niveauweb { get; set; }

        [StringLength(255)]
        public string nom { get; set; }

        [StringLength(255)]
        public string prenom { get; set; }

        [StringLength(255)]
        public string tablecategoriesniv { get; set; }
    }
}
