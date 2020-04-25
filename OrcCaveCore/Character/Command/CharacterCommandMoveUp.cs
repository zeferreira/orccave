using System;
using SDL2;

namespace OrcCave
{
    public class CharacterCommandMoveUp : ICharacterCommand
    {
        public override void Execute(CharacterBase character)
        {
            foreach (var item in Game.Instance.ActualMap.WallsLayer)
            {
                if (item != null)
                {
                    if (character.IsCollision(item.BasicObject))
                    {
                        if (character.Y > item.BasicObject.Y)
                            character.UpVelocity = -GameConfig.Instance.MoveSpeed;
                    }
                }
            }

            if (character.Y > 0)
            {
                character.Y -= character.UpVelocity + character.VelocityIncrement;
            }
            character.ActualAnimation = character.MoveUpAnimation;
            character.UpVelocity = 0;
        }

        public override bool HasFinished()
        {
            return true;
        }

    }
}
