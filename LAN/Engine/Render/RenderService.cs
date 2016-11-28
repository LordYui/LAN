using LAN.Engine.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunshineConsole;
using OpenTK.Graphics;
using LAN.Engine.Injector;

namespace LAN.Engine.Render
{
    class RenderService : IInjectable
    {
        public GameObjectManager goManager;
        ConsoleWindow gameWindow;
        public void Start()
        {
            gameWindow = new ConsoleWindow(30, 50, "Test");
        }

        public void InternalUpdate()
        {
            gameWindow.WindowUpdate();
            if (goManager == null)
                return;
            gameWindow.HoldUpdates();
            foreach (GameObject g in goManager.GetGameObjectsByComponent<RenderComponent>())
            {
                if (!g.HasComponent<Transform>())
                    continue;
                Transform t = g.GetComponent<Transform>();
                RenderComponent r = g.GetComponent<RenderComponent>();
                gameWindow.Write(t.Position.Y, t.Position.X, r.Char, Color4.White, Color4.Black);

            }
            gameWindow.ResumeUpdates();
        }
    }
}
