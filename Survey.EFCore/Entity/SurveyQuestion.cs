using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.EFCore.Entity
{
    public class SurveyQuestion
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public int SimilarQId { get; set; }

    }
}
