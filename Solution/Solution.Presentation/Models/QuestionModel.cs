﻿using Solution.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Solution.Presentation.Models
{
    public class QuestionModel

    {
   

        [Key]
        public int id_Qst { get; set; }
        public string descriptionQst { get; set; }
        public string typeQst { get; set; }

       




    }

}