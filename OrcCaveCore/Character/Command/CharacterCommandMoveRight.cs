using System;
using SDL2;

namespace OrcCave
{
    public class CharacterCommandMoveRight : ICharacterCommand
    {
        public override void Execute(CharacterBase character)
        {
            foreach (var item in Game.Instance.ActualMap.WallsLayer)
            {
                if (item != null)
                {
                    if (character.IsCollision(item.BasicObject))
                    {
                        if (character.X < item.BasicObject.X)
                            character.RightVelocity = -GameConfig.Instance.MoveSpeed;
                    }
                }
            }

            if (character.X < GameConfig.Instance.Wresolution)
            {
                character.X += character.RightVelocity + character.VelocityIncrement;
            }
            character.ActualAnimation = character.MoveRightAnimation;

            character.RightVelocity = 0;
        }

        public override bool HasFinished()
        {
            return true;
        }

        
    }
}
