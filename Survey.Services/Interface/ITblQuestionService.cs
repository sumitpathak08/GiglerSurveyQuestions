using Survey.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Services.Interface
{
    public interface ITblQuestionService
    {
        Task<IEnumerable<TblQuestionDto>> GetAllQuestions();
    }
}
