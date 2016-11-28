using LAN.Engine.ECS;
using LAN.Engine.Injector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAN.Engine
{
    class GameObject : IInjectable
    {
        public List<Component> compList = new List<Component>();
        //public bool isDirty { get; private set; }
        public virtual void Start() { }
        public virtual void Update() { }
    }

    static class GameObjectE
    {
        public static ComponentManager compManager;
        public static T AddComponent<T>(this GameObject g) where T : Component
        {
            if (compManager == null)
                throw new NullReferenceException(); // placeholder
            Component newC = compManager.CreateAndRegister<T>();
            g.compList.Add(newC);
            newC.Start();
            return (T)newC;
        }

        public static bool HasComponent<T>(this GameObject g) where T : Component
        {
            foreach(Component c in g.compList)
            {
                if (c.GetType() == typeof(T))
                    return true;
            }
            return false;
        }

        public static T GetComponent<T>(this GameObject g) where T : Component
        {
            return (T)g.compList.Where(c => c.GetType() == typeof(T)).FirstOrDefault();
        }
    }
}
