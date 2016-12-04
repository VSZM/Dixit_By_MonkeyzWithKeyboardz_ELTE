using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dixit.Common
{
    public static class Injector
    {
        public static Container Container;
        static Injector()
        {
            Container = new Container();
        }
    }
}
