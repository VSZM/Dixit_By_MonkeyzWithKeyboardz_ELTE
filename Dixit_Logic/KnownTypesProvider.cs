using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Dixit_Logic.Classes;

namespace Dixit_Logic
{
    public static class KnownTypesProvider
    {
        public static IEnumerable<Type> GetKnownTypes()
        {
            return new Type[] { typeof(Card), typeof(Deck), typeof(Hand), typeof(MainDeck) };
        }
    }
}
