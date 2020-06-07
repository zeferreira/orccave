using System;
using SDL2;

namespace OrcCave
{
    public class CharacterCommandTakeDamage : ICharacterCommand
    {
        Animation _actualAnimationAttack;
        int _damage;

        public CharacterCommandTakeDamage(int damage)
        {
            this._damage = damage;
        }

        public override void Update(CharacterBase characterTarget)
        {
            if (characterTarget.Life > 0)
            {
                characterTarget.Life -= _damage;
                this._actualAnimationAttack = characterTarget.TakeDamageAnimation;
                characterTarget.ActualAnimation = characterTarget.TakeDamageAnimation;
            }
        }

        public override bool HasFinished()
        {
            if (this._actualAnimationAttack.HasFinished)
            {
                //this._actualAnimationAttack.Reset();
                return true;
            }
            else
                return false;
        }

        public override void Cancel()
        {
            throw new NotImplementedException();
        }

        public override void Draw()
        {
            throw new NotImplementedException();
        }
    }
}
