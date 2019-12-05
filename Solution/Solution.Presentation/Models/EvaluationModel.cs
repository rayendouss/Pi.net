using Solution.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Solution.Presentation.Models
{
    [DataContract]
    public class EvaluationModel
    {
        public EvaluationModel(string TypeEval)
        {
            this.TypeEval = TypeEval;

        }

        public EvaluationModel()
        {
            ligneqsts = new HashSet<ligneqst>();
        }

        [Key]
        public int id_Eval { get; set; }

       
        public string TypeEval { get; set; }


        public string commentaire { get; set; }

        
        public string contexteEval { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? dateEval { get; set; }

        public string description { get; set; }

        public int idCandidat { get; set; }

        public int noteEmploye { get; set; }

        public int noteManager { get; set; }

        public string periodEval { get; set; }

        public int? employe_id_Emp { get; set; }

        public virtual EmployeModel employe { get; set; }

        public virtual ICollection<ligneqst> ligneqsts { get; set; }

      
    }
}