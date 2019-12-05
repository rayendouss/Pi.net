using Solution.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Solution.Presentation.Models
{
    public class LigneqstsModel
    {
        [Key]
        public int Id_LigneQst { get; set; }

        public int noteQst { get; set; }

        public int? evaluation_id_Eval { get; set; }

        public int question_id_Qst { get; set; }

        public virtual EvaluationModel evaluation { get; set; }

        public virtual QuestionModel question { get; set; }

        public virtual QuestionModel question1 { get; set; }

    }
}