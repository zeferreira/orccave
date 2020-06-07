using System;
using System.Collections;
using System.Collections.Generic;
using SDL2;

namespace OrcCave
{
    public class Animation
    {
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

        private EnumFlipAnimatonType _flipType;
        public EnumFlipAnimatonType FlipType { get => _flipType; set => _flipType = value; }

        private bool _hasFinished;
        public bool HasFinished { get => _hasFinished; set => _hasFinished = value; }

        private SpriteSheet _spriteSheet;
        public SpriteSheet SpriteSheet {  get { return _spriteSheet; } set => _spriteSheet = value;  }
        
        private TimeSpan _timeIntoAnimation;
        private TimeSpan _lastExecutionTime;

        private int _totalTimeAnimation;
        public int TotalTimeAnimation
        {
            get
            {
                this._totalTimeAnimation = 0;
                foreach (AnimationFrame item in this._frames)
                {
                    _totalTimeAnimation += item.FrameTime;
                }
                return _totalTimeAnimation;
            }
        }

        private List<AnimationFrame> _frames;
        public List<AnimationFrame> Frames { get => _frames; set => _frames = value; }

        int _actualFrameIndex = 0;
        public int ActualFrameIndex { get => _actualFrameIndex; set => _actualFrameIndex = value; }

        public AnimationFrame ActualFrame
        {
            get
            {
                return this._frames[ActualFrameIndex];
            }
        }
        
        //constructor
        public Animation(int contentSpriteSheetID)
        {
            this._frames = new List<AnimationFrame>();
            this.SpriteSheet = Game.Instance.SpriteSheetContentManager.GetSpriteSheet(contentSpriteSheetID);
            this._flipType = EnumFlipAnimatonType.None;
            this._hasFinished = false;
            this.ActualFrameIndex = 0;
            this._timeIntoAnimation = TimeSpan.Zero;
        }

        public void AddFrame(AnimationFrame frame)
        {
            this._frames.Add(frame);
            this._totalTimeAnimation += frame.FrameTime;
        }

        public void Update()
        {
            if (this._timeIntoAnimation == TimeSpan.Zero)
            {
                this._hasFinished = false;
            }

            if (this._lastExecutionTime == TimeSpan.Zero)
            {
                this._lastExecutionTime = Game.Instance.GameTime.ElapsedTimeGame;
            }

            TimeSpan actualExecutionTime = Game.Instance.GameTime.ElapsedTimeGame;

            // See if we can find the frame
            TimeSpan accumulatedTime = TimeSpan.Zero;

            for (int i = 0; i < this._frames.Count; i++)
            {
                AnimationFrame frame = this._frames[i];

                if ((accumulatedTime + (new TimeSpan(0, 0, 0, 0, frame.FrameTime)) >= _timeIntoAnimation))
                {
                    ActualFrameIndex = i;
                    break;
                }
                else
                {
                    accumulatedTime += new TimeSpan(0, 0, 0, 0, frame.FrameTime);
                }
            }

            this._timeIntoAnimation += (actualExecutionTime - _lastExecutionTime);

            if ((this._timeIntoAnimation.TotalSeconds * 1000) > TotalTimeAnimation)
            {
                this._hasFinished = true;
                //this._actualFrameIndex = 0;
                //this._timeIntoAnimation = TimeSpan.Zero;
                //this._lastExecutionTime = TimeSpan.Zero;
            }
            else
            {
                this._lastExecutionTime = actualExecutionTime;
            }
              
//#if DEBUG
//            Console.WriteLine("HasFinished:" + HasFinished);
//#endif
        }

        public void Reset()
        {
            this._hasFinished = false;
            this.ActualFrameIndex = 0;
            this._timeIntoAnimation = TimeSpan.Zero;
            this._lastExecutionTime = TimeSpan.Zero;
        }

        public virtual void Draw()
        {
            IntPtr renderer = Game.Instance.Renderer;

            SDL.SDL_Rect sourceFrameSheet = this.ActualFrame.SourceFrameSheetRect;

            SDL.SDL_RendererFlip flip = SDL.SDL_RendererFlip.SDL_FLIP_HORIZONTAL;

            switch (this.FlipType)
            {
                case EnumFlipAnimatonType.None:
                    flip = SDL.SDL_RendererFlip.SDL_FLIP_NONE;
                    break;
                case EnumFlipAnimatonType.Horizontal:
                    flip = SDL.SDL_RendererFlip.SDL_FLIP_HORIZONTAL;
                    break;
                case EnumFlipAnimatonType.Vertical:
                    flip = SDL.SDL_RendererFlip.SDL_FLIP_VERTICAL;
                    break;

                default:
                    break;
            }

            SDL.SDL_RenderCopyEx(renderer, this.SpriteSheet.Texture, ref sourceFrameSheet, ref this._targetRect, 0.0, IntPtr.Zero, flip);
        }

    }
}
