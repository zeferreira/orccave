using System;
using System.Collections.Generic;


namespace OrcCave
{
    public interface IController
    {
        void Update();
        ICharacterCommand GetCommand();
        InputState GetInputState();
    }
}
