using System;
using SDL2;

namespace OrcCave
{
    public class CharacterCommandBasicAttack : ICharacterCommand
    {
        Animation _actualAnimationAttack;
        
        public override void Execute(CharacterBase character)
        {
            //hero
            if (character.CharacterType == EnumCharacterType.Hero)
            {
                foreach (var item in Game.Instance.ActualQuest.ActualEnemyList)
                {
                    if (character.IsCollision(item))
                    {
                        if (item.Life > 0)
                        {
                            item.Life -= character.Strenght;
                            item.ActualAnimation = item.TakeDamageAnimation;
                        }
                    }
                }
            }

            //enemies
            if (character.CharacterType == EnumCharacterType.Enemy)
            {
                CharacterBase player = Game.Instance.Player;
                    if (character.IsCollision(player))
                    {
                        if (player.Life > 0)
                        {
                            player.Life -= character.Strenght;
                            player.ActualAnimation = player.TakeDamageAnimation;
                        }
                    }
            }
            
            character.ActualAnimation = character.BasicAttackAnimation;
            this._actualAnimationAttack = character.BasicAttackAnimation;
            this._actualAnimationAttack.Reset();

#if DEBUG
            Console.WriteLine(character.BasicAttackAnimation.HasFinished);
#endif 
        }

        public override bool HasFinished()
        {
            if (this._actualAnimationAttack.HasFinished)
            {
                return true;
            }
            else
                return false;
        }
    }
}
