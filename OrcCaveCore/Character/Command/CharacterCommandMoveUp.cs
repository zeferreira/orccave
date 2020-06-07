using System;
using SDL2;

namespace OrcCave
{
    public class CharacterCommandMoveUp : ICharacterCommand
    {
        private bool _isCanceled = false;
        private bool _isFinished = false;
        private bool _isEffectApplied = false;

        private CharacterBase _character;
        private Animation _animation;
        private bool _firstExecution = true;

        public override void Update(CharacterBase character)
        {
            if (this._firstExecution)
            {
                this._animation = character.MoveUpAnimation;
                if (_animation.HasFinished)
                {
                    this._animation.Reset();
                }
            }

            if (this._isCanceled)
            {
                this._isFinished = true;
                this._isCanceled = true;
                this._animation.Reset();
            }
            else
            {
                this._animation = character.MoveUpAnimation;
                this._character = character;

                this._animation.X = this._character.X;
                this._animation.Y = this._character.Y;
                this._animation.W = this._character.W;
                this._animation.H = this._character.H;

                this._animation.Update();
                this._isFinished = this._animation.HasFinished;
            }

            this._firstExecution = false;

            if (!this._isEffectApplied)
            {
                //walls layer
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
                this._isEffectApplied = true;
            }
        }

        public override bool HasFinished()
        {
            if (_firstExecution)
                return false;
            else
                return this._animation.HasFinished;
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
            if (_firstExecution)
                return false;
            else
                return true;
        }
    }
}
