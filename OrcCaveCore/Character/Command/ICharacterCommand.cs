using System;
using SDL2;

namespace OrcCave
{
    public abstract class ICharacterCommand
    {    
        public abstract void Execute(CharacterBase character);

        public abstract bool HasFinished();

    }
}
