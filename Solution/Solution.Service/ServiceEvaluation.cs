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
    public class ServiceEvaluation : Service<evaluation>, IServiceEvaluation
    {

        private static IDatabaseFactory dbfactory = new DatabaseFactory();
        private static IUnitOfWork UOW = new UnitOfWork(dbfactory);
        private ff db = new ff();
        public ServiceEvaluation() : base(UOW)
        {
        }


    }
}
