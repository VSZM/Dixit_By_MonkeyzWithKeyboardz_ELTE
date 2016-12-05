﻿using System;
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
        [DataMember]
        public bool Success;
        [DataMember]
        public string ErrorMessage;
    }
}