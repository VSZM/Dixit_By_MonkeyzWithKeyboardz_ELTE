using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dixit_Service.Data
{
    [DataContract]
    public class Player
    {
        [DataMember]
        public string Name;
    }
}
