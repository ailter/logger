using ORLogger.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORLogger.Concretes.Logger
{
    public class DBLogger : LogBase
    {
        public override void Log(string message, bool isError)
        {
            throw new NotImplementedException();
        }
    }
}
