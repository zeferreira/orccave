using System;
using SDL2;
using OrcCave;
using System.Runtime.InteropServices;

namespace ConsoleTestGuiSDL
{
    class Program
    {
        static void Main(string[] args)
        {
            GameConfig config = GameConfig.Instance;

            //good resolution for Android/Windows Phone
            config.Hresolution = 480;
            config.Wresolution = 800;
            //good frame rate for Dungeon Sprite Sheet from Pita
            config.DefaultAnimationFrameTime = 100;
            config.ImageFolder = @"Images\";

            //player move speed
            config.MoveSpeed = 2;
            config.ToleranceCollision = 1;
            config.CommandQueueCapacity = 10;

            Game game = Game.Instance;

            game.Run();
        }

    }
}
