using System;
using System.Collections.Generic;

namespace Survey.EFCore.Entity;

public partial class TblSurveyQuestion
{
    public int Id { get; set; }

    public string Question { get; set; } = null!;

    public int? SimilarQid { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? ModifyBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    //public virtual ICollection<TblSurveyQuestion> InverseSimilarQ { get; set; } = new List<TblSurveyQuestion>();

    //public virtual TblSurveyQuestion? SimilarQ { get; set; }
}
