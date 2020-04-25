using System;
using SDL2;

namespace OrcCave
{
    public class CharacterStateWalking : ICharacterState
    {
        private int _steps;

        private CharacterBase _baseChar;
        GameConfig config = GameConfig.Instance;

        public CharacterStateWalking(CharacterBase baseChar)
        {
            this._baseChar = baseChar;
            this._steps = 0;
        }

        public virtual void Update()
        {
            Random rnd = new Random();
            ICharacterCommand command;

            int direction = rnd.Next(1, 4);
            this._steps = rnd.Next(1, 4);

            switch (direction)
            {
                case 1:
                    command = new CharacterCommandMoveRight();
                    break;
                case 2:
                    command = new CharacterCommandMoveLeft();
                    break;
                case 3:
                    command = new CharacterCommandMoveUp();
                    break;
                case 4:
                    command = new CharacterCommandMoveDown();
                    break;

                default:
                    command = new CharacterCommandIdle();
                    break;
            }

            while (_steps > 0)
            {
                this._baseChar.AddCommand(command);
                this._steps--;
            }

            this._baseChar.IACharacterState = new CharacterStateBasicAttack(_baseChar);
//#if DEBUG
//            Console.WriteLine("Attack: " + GameTime.Instance.ElapsedTimeGame.ToString());
//#endif

        }
    }
}