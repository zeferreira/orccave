using System;
using System.Collections;
using System.Collections.Generic;
using SDL2;

namespace OrcCave
{
    public class AnimationFrame
    {
        private SDL.SDL_Rect _sourceFrameSheetRect;

        public int X
        {
            get { return this._sourceFrameSheetRect.x; }
            set { this._sourceFrameSheetRect.x = value; }
        }

        public int Y
        {
            get { return this._sourceFrameSheetRect.y; }
            set { this._sourceFrameSheetRect.y = value; }
        }

        public int W
        {
            get { return this._sourceFrameSheetRect.w; }
            set { this._sourceFrameSheetRect.w = value; }
        }

        public int H
        {
            get { return this._sourceFrameSheetRect.h; }
            set { this._sourceFrameSheetRect.h = value; }
        }

        public SDL.SDL_Rect SourceFrameSheetRect { get => _sourceFrameSheetRect; set => _sourceFrameSheetRect = value; }

        private int _frameTime;
        public int FrameTime { get => _frameTime; set => _frameTime = value; }

        public AnimationFrame(int x, int y, int w, int h, int frameTime)
        {
            this.X = x;
            this.Y = y;
            this.H = h;
            this.W = w;

            this._frameTime = frameTime;
        }

        /// <summary>
        /// use a default framerate from GameConfig
        /// </summary>
        public AnimationFrame(int x, int y, int w, int h)
        {
            this.X = x;
            this.Y = y;
            this.H = h;
            this.W = w;

            this._frameTime = GameConfig.Instance.FrameRate;
        }
    }
}
