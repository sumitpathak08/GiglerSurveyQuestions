using Survey.EFCore.DataContext;
using Survey.EFCore.Entity;
using Survey.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Repository.Infra_Implement
{
    public class TblQuestionRepo : BaseRepository<TblSurveyQuestion>, ITblQuestionRepo
    {
        public TblQuestionRepo(SurveyDBContext context) : base(context)
        {

        }
    }
}