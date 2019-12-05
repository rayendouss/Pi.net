using Service.Pattern;
using ServicePattern;
using Solution.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Service
{
   public interface IQuestionService : IService<question>
    {
        question getByIds(int id);
    }

}
