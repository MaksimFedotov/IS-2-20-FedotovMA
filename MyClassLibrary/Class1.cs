using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public class DBconnection
    {
        protected string _connectString;


        public DBconnection(string connectString)
        {
            this._connectString = connectString;

        }

        public string GetConnectionString()
        {
            return this._connectString;
        }
    }
}
