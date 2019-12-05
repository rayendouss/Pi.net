using Service.Pattern;
using ServicePattern;
using Solution.Data;
using Solution.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Service
{
    public class QuestionService : Service <question>, IQuestionService
    {
        static IDatabaseFactory factory = new DatabaseFactory();
        static IUnitOfWork UTK = new UnitOfWork(factory);
        private ff db = new ff();
        public QuestionService() : base(UTK)
        {

        }

        public question getByIds(int id)
        {
            return db.questions.Where(o => o.id_Qst == id).SingleOrDefault();
        }
    }
}
