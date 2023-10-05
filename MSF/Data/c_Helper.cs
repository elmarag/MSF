using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSF.Data
{
    public class CHelper
    { 
        public static string CnnVal(String name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
