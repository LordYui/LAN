using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LAN.Engine.Injector
{
    static class DependencyInjector
    {
        static List<IInjectable> injectableObjects = new List<IInjectable>();
        public static void RegisterInjectableObject(IInjectable inj)
        {
            injectableObjects.Add(inj);
        }

        public static void Inject(this IInjectable o)
        {
            MethodInfo mInf = o.GetType().GetMethod("OnInject");
            if (mInf == null)
                return;
            List<IInjectable> retArgs = new List<IInjectable>();
            foreach(Type t in mInf.GetGenericArguments())
            {
                IInjectable retArg = injectableObjects.Where(tI => tI.GetType() == t).First();
                if (retArg == null)
                    continue;
                retArgs.Add(retArg);
            }
            mInf.Invoke(o, retArgs.ToArray());
        }
    }
}
