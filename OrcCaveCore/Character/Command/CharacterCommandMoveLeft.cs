using System;
using SDL2;

namespace OrcCave
{
    public class CharacterCommandMoveLeft : ICharacterCommand
    {
        public override void Execute(CharacterBase character)
        {
            foreach (var item in Game.Instance.ActualMap.WallsLayer)
            {
                if (item != null)
                {
                    if (character.IsCollision(item.BasicObject))
                    {
                        if (character.X > item.BasicObject.X)
                            character.LeftVelocity= -GameConfig.Instance.MoveSpeed;
                    }
                }
            }

            if (character.X > 0)
            {
                character.X -= character.LeftVelocity + character.VelocityIncrement;
            }
            character.ActualAnimation = character.MoveLeftAnimation;
            character.LeftVelocity = 0;
        }

        public override bool HasFinished()
        {
            return true;
        }

    }
}
