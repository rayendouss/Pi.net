using Solution.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Solution.Presentation.Models
{
    public class EmployeModel
    {
        public EmployeModel()
        {
            evaluations = new HashSet<EvaluationModel>();
        }


        [Key]
        public int id_Emp { get; set; }

        public string email { get; set; }

        public bool? isActif { get; set; }
        public string nom { get; set; }
        public string password { get; set; }
        public string prenom { get; set; }
        public virtual ICollection<EvaluationModel> evaluations { get; set; }
    }
}