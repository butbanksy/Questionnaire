﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.Models
{
    public class Question
    {
        public int Id { get; set; }
        
        public string Title { get; set; }

        public IEnumerable<Option> Options { get; set; }
    }
}
