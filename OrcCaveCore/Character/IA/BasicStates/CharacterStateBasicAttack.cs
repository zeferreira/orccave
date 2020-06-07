using System;
using SDL2;

namespace OrcCave
{
    public class CharacterStateBasicAttack : ICharacterState
    {
        private int _steps;

        private CharacterBase _baseChar;
        GameConfig config = GameConfig.Instance;

        public CharacterStateBasicAttack(CharacterBase baseChar)
        {
            this._baseChar = baseChar;
            this._steps = 0;
        }

        public virtual void Update()
        {
            this._baseChar.AddCommand(new CharacterCommandBasicAttack());

            this._baseChar.IACharacterState = new CharacterStateWalking(_baseChar);
        }
    }
}