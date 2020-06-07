using System;
using SDL2;

namespace OrcCave
{
    public class GameObject
    {
        //Physics section
        private int _rightVelocity;
        public int RightVelocity { get => _rightVelocity; set => _rightVelocity = value; }

        private int _leftVelocity;
        public int LeftVelocity { get => _leftVelocity; set => _leftVelocity = value; }

        private int _upVelocity;
        public int UpVelocity { get => _upVelocity; set => _upVelocity = value; }

        private int _downVelocity;
        public int DownVelocity { get => _downVelocity; set => _downVelocity = value; }

        private int _velocityIncrement;
        public int VelocityIncrement { get => _velocityIncrement; set => _velocityIncrement = value; }
        //Physics section

        //animation section
        private Animation _actualAnimation;
        public Animation ActualAnimation { get => _actualAnimation; set => _actualAnimation = value; }

        private AnimationFrame _actualFrame;
        public AnimationFrame ActualFrame { get => _actualFrame; set => _actualFrame = value; }
        //animation section 

        protected SDL.SDL_Rect _targetRect;

        public int X
        {
            get { return this._targetRect.x; }
            set { this._targetRect.x = value; }
        }

        public int Y
        {
            get { return this._targetRect.y; }
            set { this._targetRect.y = value; }
        }

        public int W
        {
            get { return this._targetRect.w; }
            set { this._targetRect.w = value; }
        }

        public int H
        {
            get { return this._targetRect.h; }
            set { this._targetRect.h = value; }
        }

        public GameObject(int x, int y, int w, int h)
        {
            this._targetRect.x = x;
            this._targetRect.y = y;
            this._targetRect.h = h;
            this._targetRect.w = w;
        }

        //can you use physics for collision?
        //do you need a interface? yes.
        public bool IsCollision(GameObject basicObjectTarget)
        {
            SDL.SDL_Rect source = this._targetRect;
            SDL.SDL_Rect target = basicObjectTarget._targetRect;

            source.x += GameConfig.Instance.ToleranceCollision;
            source.y += GameConfig.Instance.ToleranceCollision;
            source.h -= GameConfig.Instance.ToleranceCollision;
            source.w -= GameConfig.Instance.ToleranceCollision;

            target.x += GameConfig.Instance.ToleranceCollision;
            target.y += GameConfig.Instance.ToleranceCollision;
            target.h -= GameConfig.Instance.ToleranceCollision;
            target.w -= GameConfig.Instance.ToleranceCollision;

            SDL.SDL_bool collision = SDL.SDL_HasIntersection(ref source, ref target);

            switch (collision)
            {
                case SDL.SDL_bool.SDL_TRUE: return true;
                case SDL.SDL_bool.SDL_FALSE: return false;
                default: throw new ArgumentOutOfRangeException("value");
                    // ^^^ yes, that is possible
            }
        }
    }
}
