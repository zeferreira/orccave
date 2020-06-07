using System;
using SDL2;

namespace OrcCave
{
    public abstract class ICharacterCommand
    {
        private bool _isCanceled = false;
        private bool _isFinished = false;
               
        public abstract void Update(CharacterBase character);
        public abstract void Cancel();

        public abstract void Draw();

        public virtual bool HasFinished()
        {
            return _isFinished;
        }
        public virtual bool HasCanceled()
        {
            return _isCanceled;
        }

        public virtual bool CanCancel()
        {
            return false;
        }
    }
}
