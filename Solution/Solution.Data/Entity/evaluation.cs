namespace Solution.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidevgl.evaluation")]
    public partial class evaluation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public evaluation()
        {
            ligneqsts = new HashSet<ligneqst>();
        }

        [Key]
        public int id_Eval { get; set; }

        [StringLength(255)]
        public string TypeEval { get; set; }

        [StringLength(255)]
        public string commentaire { get; set; }

        [StringLength(255)]
        public string contexteEval { get; set; }

        public DateTime? dateEval { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        public int idCandidat { get; set; }

        public int noteEmploye { get; set; }

        public int noteManager { get; set; }

        [StringLength(255)]
        public string periodEval { get; set; }

        public int? employe_id_Emp { get; set; }



        public virtual employe employe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ligneqst> ligneqsts { get; set; }
    }
}
