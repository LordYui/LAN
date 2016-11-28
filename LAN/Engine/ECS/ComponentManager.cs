using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAN.Engine.ECS
{
    class ComponentManager
    {
        List<Component> compList = new List<Component>();
        public void RegisterComponent(Component c)
        {
            compList.Add(c);
        }

        public T CreateAndRegister<T>() where T : Component
        {
            T ret = Activator.CreateInstance<T>();
            RegisterComponent(ret);
            return ret;
        }

        public void Update()
        {
            foreach(Component c in compList)
            {
                c.Update();
            }
        }
    }
}
