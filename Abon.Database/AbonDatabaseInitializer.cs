using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abon.Database
{
    public class AbonDatabaseInitializer : DropCreateDatabaseIfModelChanges<AbonContext>
    {
    }
}
