using System;
using SDL2;

namespace OrcCave
{
    public class CharacterCommandIdle : ICharacterCommand
    {
        private bool _isCanceled = false;
        private bool _isFinished = false;
        private CharacterBase _character;
        private Animation _animation;

        private bool _firstExecution = true;
        
        public override void Update(CharacterBase character)
        {
            if (this._firstExecution)
            {
                this._animation = character.IdleAnimation;
                this._animation.Reset();
            }

            if (this._isCanceled)
            {
                this._isFinished = true;
                this._isCanceled = true;
                this._animation.Reset();
            }
            else
            {
                this._animation = character.IdleAnimation;
                this._character = character;

                this._animation.X = this._character.X;
                this._animation.Y = this._character.Y;
                this._animation.W = this._character.W;
                this._animation.H = this._character.H;

                this._animation.Update();
                this._isFinished = this._animation.HasFinished;
            }

            this._firstExecution = false;
        }

        public override bool HasFinished()
        {
            return this._isFinished;
        }

        public override void Cancel()
        {
            this._isCanceled = true;
        }

        public override void Draw()
        {
            this._animation.Draw();
        }

        public override bool HasCanceled()
        {
            return this._isCanceled;
        }

        public override bool CanCancel()
        {
            return true;
        }
    }
}
