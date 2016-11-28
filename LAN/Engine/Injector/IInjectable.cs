using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAN.Engine.Injector
{
    abstract class IInjectable
    {
        public IInjectable()
        {
            DependencyInjector.RegisterInjectableObject(this);
        }
    }
}
