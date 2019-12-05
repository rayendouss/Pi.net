namespace Pidev.data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

 
    public partial class tp_jsf_employe
    {
        public int id { get; set; }

        [StringLength(255)]
        public string email { get; set; }

        [Column(TypeName = "bit")]
        public bool? isActif { get; set; }

        [StringLength(255)]
        public string nom { get; set; }

        [StringLength(255)]
        public string password { get; set; }

        [StringLength(255)]
        public string prenom { get; set; }

        [StringLength(255)]
        public string role { get; set; }
    }
}
