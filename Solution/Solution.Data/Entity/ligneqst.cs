namespace Solution.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidevgl.ligneqst")]
    public partial class ligneqst
    {
        [Key]
        public int Id_LigneQst { get; set; }

        public int noteQst { get; set; }

        public int? evaluation_id_Eval { get; set; }

        public int question_id_Qst { get; set; }

        public virtual evaluation evaluation { get; set; }

        public virtual question question { get; set; }

        public virtual question question1 { get; set; }
    }
}
