using System;
using SDL2;

namespace OrcCave
{
    public class CharacterCommandMoveDown : ICharacterCommand
    {
        public override void Execute(CharacterBase character)
        {
            foreach (var item in Game.Instance.ActualMap.WallsLayer)
            {
                if (item != null)
                {
                    if (character.IsCollision(item.BasicObject))
                    {
                        if (character.Y < item.BasicObject.Y)
                            character.DownVelocity = -GameConfig.Instance.MoveSpeed;
                    }
                }
            }

            if (character.Y < GameConfig.Instance.Hresolution)
            {
                character.Y += character.DownVelocity + character.VelocityIncrement;
            }
            character.ActualAnimation = character.MoveDownAnimation;
            character.DownVelocity = 0;
        }

        public override bool HasFinished()
        {
            return true;
        }

    }
}
