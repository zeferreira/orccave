using System;
using System.Collections;
using System.Collections.Generic;
//using SDL2;

namespace OrcCave
{
    public class Animation
    {
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
        public AnimationFrame ActualFrame
        {
            get
            {
                return this._frames[_actualFrameIndex];
            }
        }
        
        //constructor
        public Animation(int contentSpriteSheetID)
        {
            this._frames = new List<AnimationFrame>();
            this.SpriteSheet = Game.Instance.SpriteSheetContentManager.GetSpriteSheet(contentSpriteSheetID);
            this._flipType = EnumFlipAnimatonType.None;
            this._hasFinished = false;
            this._actualFrameIndex = 0;
            this._timeIntoAnimation = TimeSpan.Zero;
        }

        public void AddFrame(AnimationFrame frame)
        {
            this._frames.Add(frame);
            this._totalTimeAnimation += frame.FrameTime;
        }

        //public AnimationFrame GetNextFrameOriginal()
        //{
        //    uint ticks = SDL.SDL_GetTicks();

        //    _actualFrameIndex = (int)(ticks / Frames[_actualFrameIndex].FrameTime) % (int)this._frames.Count;

        //    if (_actualFrameIndex == (Frames.Count - 1))
        //    {
        //        this._hasFinished = true;
        //    }
        //    else this._hasFinished = false;

            
        //    return Frames[_actualFrameIndex];
        //}

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
                    _actualFrameIndex = i;
                    break;
                }
                else
                {
                    accumulatedTime += new TimeSpan(0, 0, 0, 0, frame.FrameTime);
                }
            }

            this._timeIntoAnimation += (actualExecutionTime - _lastExecutionTime);

            if ((this._timeIntoAnimation.TotalSeconds*1000) > TotalTimeAnimation)
            {
                this._hasFinished = true;
                this._actualFrameIndex = 0;
                this._timeIntoAnimation = TimeSpan.Zero;
            }

            this._lastExecutionTime = actualExecutionTime;
#if DEBUG
            Console.WriteLine("HasFinished:" + HasFinished);
#endif
        }

        public void Reset()
        {
            this._hasFinished = false;
            this._actualFrameIndex = 0;
            this._timeIntoAnimation = TimeSpan.Zero;
        }
    }
}
