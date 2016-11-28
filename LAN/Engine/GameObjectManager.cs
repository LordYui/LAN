using LAN.Engine.ECS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAN.Engine
{
    class GameObjectManager
    {
        public List<GameObject> GameObjects;
        public GameObjectManager()
        {
            GameObjects = new List<GameObject>();
        }

        public void RegisterGameObject(GameObject g)
        {
            GameObjects.Add(g);
        }

        public GameObject[] GetGameObjectsByComponent<T>() where T : Component
        {
            return GameObjects.Where(g => g.HasComponent<T>()).ToArray();
        }
    }
}
