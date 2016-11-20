using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Dixit_Service.DataContracts
{
    [DataContract]
    public class Card
    {
        public int Id { get; set; }
    }
}