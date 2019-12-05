using Solution.Data.Infrastructure;
using Solution.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private ff dataContext;
        public ff DataContext { get { return dataContext; } }

        public DatabaseFactory()
        {
            dataContext = new ff();
        }
        protected override void DisposeCore()
        {
            if (DataContext != null)
                DataContext.Dispose();
        }
      
    }

}
