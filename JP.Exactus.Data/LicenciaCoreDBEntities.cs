using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JP.Exactus.Data
{
    public partial class LicenciaCoreDBEntities 
    {
        public LicenciaCoreDBEntities(DbConnection existingConnection, bool ownsConnection) 
            : base(existingConnection, ownsConnection)
        { }
    }
}
