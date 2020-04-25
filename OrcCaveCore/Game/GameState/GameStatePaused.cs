using System;
using SDL2;

namespace OrcCave
{
    public class GameStatePaused : IGameState
    {
        Game _gameBase;
        IGameState _lastGamePlaingState;

        public GameStatePaused(Game gameBase, IGameState _lastState)
        {
            this._gameBase = gameBase;
            this._lastGamePlaingState = _lastState;
            this._gameBase.GameTime.PauseClock();
        }

        public void LoadContent()
        {

        }

        public void UnloadContent()
        {

        }

        public void Update()
        {
            SDL.SDL_Event e;

            while (SDL.SDL_PollEvent(out e) != 0)
            {
                switch (e.type)
                {
                    case SDL.SDL_EventType.SDL_QUIT:
                        this._gameBase.GameState = new GameStateQuit(this._gameBase);
                        break;
                    case SDL.SDL_EventType.SDL_KEYDOWN:
                        switch (e.key.keysym.sym)
                        {
                            case SDL.SDL_Keycode.SDLK_q:
                                this._gameBase.GameState = new GameStateQuit(this._gameBase);
                                break;
                            case SDL.SDL_Keycode.SDLK_ESCAPE:
                                this._gameBase.GameState = new GameStateQuit(this._gameBase);
                                break;
                            case SDL.SDL_Keycode.SDLK_p:
                                this._gameBase.GameTime.StartClock();
                                this._gameBase.GameState = _lastGamePlaingState;
                                break;
                        }
                        break;
                    default://first switch
                        break;
                }

            }//while

            //local state updates
            //this._gameBase.Player.Update();
            //this._gameBase.ActualQuest.Update();
            //this._gameStatusBar.Update();
        }

        public void Draw()
        {
            this._lastGamePlaingState.Draw();
        }

    }
}
