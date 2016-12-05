using Dixit_Data;
using Dixit_Data.Interfaces;
using Dixit_Logic.Classes;
using Dixit_Logic.Interfaces;
using SimpleInjector;

namespace Dixit.Common
{
    public static class Injector
    {
        public static readonly Container Container;

        static Injector()
        {
            Container = new Container();

            Container.Register<IDixitGame, DixitGame>(Lifestyle.Singleton);
            Container.Register<ICardAccess, CardAccess>(Lifestyle.Singleton);

            Container.Verify();
        }
    }
}
