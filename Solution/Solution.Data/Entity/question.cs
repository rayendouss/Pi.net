namespace Solution.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidevgl.question")]
    public partial class question
    {
        

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public question()
        {
            ligneqsts = new HashSet<ligneqst>();
            ligneqsts1 = new HashSet<ligneqst>();
        }

        [Key]
        public int id_Qst { get; set; }

        [StringLength(255)]
        public string descriptionQst { get; set; }

        [StringLength(255)]
        public string typeQst { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ligneqst> ligneqsts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ligneqst> ligneqsts1 { get; set; }
    }
}
