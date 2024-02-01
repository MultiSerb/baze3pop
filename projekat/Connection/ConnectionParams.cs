using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak.Connection
{
    public class ConnectionParams
    {
        public static readonly string LOCAL_DATA_SOURCE = "//localhost:1521/xe";
        public static readonly string CLASSROOM_DATA_SOURCE = "//192.168.0.102:1522/db2016";

        public static readonly string USER_ID = "projekat";  // prva tacka
        public static readonly string PASSWORD = "ftn";
    }
}
