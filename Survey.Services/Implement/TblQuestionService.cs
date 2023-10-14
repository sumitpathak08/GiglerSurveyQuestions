using Survey.DTO;
using Survey.EFCore.Entity;
using Survey.Infra.Interfaces;
using Survey.Services.Interface;
using Survey.Services.ModelMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Services.Implement
{
    public class TblQuestionService : ITblQuestionService
    {
        private readonly IMapperFactory _mapperFactory;
        private ITblQuestionRepo _repository { get; set; }
        public TblQuestionService(ITblQuestionRepo repository, IMapperFactory mapperFactory)
        {
            _mapperFactory = mapperFactory;
            _repository = repository;
        }
        public async Task<IEnumerable<TblQuestionDto>> GetAllQuestions()
        {
            List<TblSurveyQuestion> questionList = new List<TblSurveyQuestion>();
            questionList = await _repository.GetAllAsync();
            var getRandomQ = TakeRandom(questionList, 5).ToList(); 
            var randomQ = recursionCall(getRandomQ, questionList);      
            return _mapperFactory.GetList<TblSurveyQuestion, TblQuestionDto>(randomQ.ToList());
        }
        public List<TblSurveyQuestion> recursionCall(IEnumerable<TblSurveyQuestion> collection, List<TblSurveyQuestion> questionList)
        {
            List<int?> intSimilarQId = new List<int?>();
            var listItem = collection.ToList();
            intSimilarQId.AddRange(listItem.Select(x => x.SimilarQid).ToList());
            var hasDuplicates = intSimilarQId.GroupBy(x => x).Any(x => x.Skip(1).Any());
            if (hasDuplicates)
            {
                listItem = recursionCall(TakeRandom(questionList, 5).ToList(), questionList);
            }
            return listItem;
        }
        public IEnumerable<TblSurveyQuestion> TakeRandom<TblSurveyQuestion>(IEnumerable<TblSurveyQuestion> collection, int take)
        {
            var random = new Random();
            var available = collection.Count();
            var needed = take;
            foreach (var item in collection)
            {
                if (random.Next(available) < needed)
                {

                    needed--;
                    yield return item;
                    if (needed == 0)
                    {
                        break;
                    }
                }
                available--;
            }
        }
    }
}
