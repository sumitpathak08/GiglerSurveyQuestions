using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.DTO
{
    public class TblQuestionDto
    {
        public int Id { get; set; }

        public string Question { get; set; } = null!;

        public int? SimilarQid { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? ModifyBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
