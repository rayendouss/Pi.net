using Pidev.data;
using Pidev.Data.Infrastructure;
using Pidev.servicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pidev.service
{
   public class Projet : Service<tp_jsf_project> ,IProjet
    {
      static IDatabaseFactory factory = new DatabaseFactory();
    static IUnitOfWork UOW = new UnitOfWork(factory);
        public Projet() : base(UOW)
        {

        }
    }
}
