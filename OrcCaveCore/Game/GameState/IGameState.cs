using System;
using SDL2;

namespace OrcCave
{
    public interface IGameState
    {
        void LoadContent();

        void UnloadContent();

        void Update();

        void Draw();
    }

}
