using Service.Pattern;
using ServicePattern;
using Solution.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Service
{
    public interface ILigneqst : IService<ligneqst>
    {
        IEnumerable<question> GetligneqstByEvaluation(int evaluationId);
    }
}
