using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abon.Database.Model;

namespace Abon.Database.Initializers
{
    public interface IDbInitializer<T> where T : ModelBase
    {
        List<T> Initialize();
    }
}
