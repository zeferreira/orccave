using System;
using SDL2;
using OrcCave;


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
            config.FrameRate = 100;
            config.ImageFolder = @"Images\";

            //player move speed
            config.MoveSpeed = 5;
            config.ToleranceCollision = 2;
            config.CommandQueueCapacity = 5;

            Game game = Game.Instance;

            game.Run();
        }
    }
}
