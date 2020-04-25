using System;
using SDL2;

namespace OrcCave
{
    public interface ICharacterLoader
    {
        CharacterBase Load();
    }
}
