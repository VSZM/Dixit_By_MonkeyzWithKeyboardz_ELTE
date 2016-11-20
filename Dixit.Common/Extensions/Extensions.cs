using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class Extensions
    {
        public static void Raise(this EventHandler @event, object sender, EventArgs e = null)
        {
            if (@event != null)
                @event(sender, e ?? EventArgs.Empty);
        }

        public static void Raise<T>(this EventHandler<T> @event, object sender, T e) where T : EventArgs
        {
            if (@event != null)
                @event(sender, e);
        }
    }
}
