using System;
using SDL2;

namespace OrcCave
{
    public class CharacterCommandIdle : ICharacterCommand
    {
        public override void Execute(CharacterBase character)
        {
            character.ActualAnimation = character.IdleAnimation;
        }

        public override bool HasFinished()
        {
            return true;
        }

    }
}
