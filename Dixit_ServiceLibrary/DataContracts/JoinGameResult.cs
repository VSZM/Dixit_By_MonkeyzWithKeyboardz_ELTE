using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dixit_ServiceLibrary.DataContracts
{
    [DataContract]
    public class JoinGameResult
    {
        public bool Success;
        public string ErrorMessage;
    }
}
