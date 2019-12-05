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
    public class LigneqstService : Service<ligneqst>, ILigneqst
    {
        static IDatabaseFactory factory = new DatabaseFactory();
        static IUnitOfWork UTK = new UnitOfWork(factory);
        public LigneqstService() : base(UTK)
        {

        }
        

        IEnumerable<question> ILigneqst.GetligneqstByEvaluation(int evaluationId)
        {
            throw new NotImplementedException();
        }
    }
}
