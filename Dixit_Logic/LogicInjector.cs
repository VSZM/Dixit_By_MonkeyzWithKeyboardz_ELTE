using Dixit_Logic.Classes;
using Dixit_Logic.Interfaces;
using SimpleInjector;

namespace Dixit.Injectors
{
    public static class LogicInjector
    {
        public static readonly Container Container;

        static LogicInjector()
        {
            Container = new Container();

            Container.Register<IDixitGame, DixitGame>(Lifestyle.Singleton);

            Container.Verify();
        }
    }
}
