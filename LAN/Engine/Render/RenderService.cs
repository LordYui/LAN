using LAN.Engine.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAN.Engine.Render
{
    class RenderService
    {
        public GameObjectManager goManager;
        public void Start()
        {
            
        }

        public void Update()
        {
            if (goManager == null)
                return;
            foreach(GameObject g in goManager.GetGameObjectsByComponent<RenderComponent>())
            {
                if (!g.HasComponent<Transform>())
                    continue;
                // todo: render shit
            }
        }
    }
}
