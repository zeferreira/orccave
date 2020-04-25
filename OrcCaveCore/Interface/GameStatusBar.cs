using System;
using System.Collections.Generic;
using SDL2;


namespace OrcCave
{
    public class GameStatusBar
    {
        Game _current;

        SDL.SDL_Rect _target;
        IntPtr _surface;
        IntPtr _texture;
        IntPtr _font;
        SDL.SDL_Color _color;
        string _textMessage;

        public GameStatusBar(Game game)
        {
            this._current = game;
            this._target = new SDL.SDL_Rect();
            
            this._font = SDL_ttf.TTF_OpenFont("arial.ttf", 15);
            this._color = new SDL.SDL_Color();
            _color.r = 255;
            _color.g = 255;
            _color.b = 255;
        }

        public void Update()
        {
            string paused = "";

            if (_current.GameState is GameStatePaused)
                paused = " - Pause";
            
            _textMessage = "Game Time:" + _current.GameTime.ElapsedTimeGame.ToString() + paused;
        }

        public void Draw()
        {
            this._surface = SDL_ttf.TTF_RenderText_Solid(this._font, _textMessage, this._color);
            this._texture = SDL.SDL_CreateTextureFromSurface(Game.Instance.Renderer, this._surface);

            int texW = 0;
            int texH = 0;
            uint format;
            int access;
            SDL.SDL_QueryTexture(this._texture, out format, out access, out texW, out texH);

            //= { 0, 0, texW, texH };
            this._target.x = GameConfig.Instance.Wresolution / 2;
            this._target.y = 10;
            this._target.w = texW;
            this._target.h = texH;

            SDL.SDL_RenderCopy(Game.Instance.Renderer, this._texture, IntPtr.Zero, ref this._target);
            SDL.SDL_DestroyTexture(this._texture);
            SDL.SDL_FreeSurface(_surface);
        }


    }
}
