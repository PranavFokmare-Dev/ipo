using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface LoggerManager
    {
        void LogInfo(string message);
        void LogDebug(string message);
        void LogWarn(string message);
        void LogError(string message);
    }
}
