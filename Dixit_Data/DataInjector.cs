using Dixit_Data;
using Dixit_Data.Interfaces;
using SimpleInjector;

namespace Dixit.Injectors
{
    public static class DataInjector
    {
        public static readonly Container Container;

        static DataInjector()
        {
            Container = new Container();

            Container.Register<ICardAccess, CardAccess>(Lifestyle.Singleton);

            Container.Verify();
        }
    }
}
