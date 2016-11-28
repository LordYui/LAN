using LAN.Engine.ECS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAN.Engine
{
    class GameObject
    {
        public List<Component> compList = new List<Component>();
    }

    static class GameObjectE
    {
        public static ComponentManager compManager;
        public static void AddComponent<T>(this GameObject g) where T : Component
        {
            if (compManager == null)
                throw new NullReferenceException(); // placeholder
            Component newC = compManager.CreateAndRegister<T>();
            g.compList.Add(newC);
            newC.Start();

        }
    }
}
