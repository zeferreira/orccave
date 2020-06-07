using System;
using System.Runtime.InteropServices;
using SDL2;

namespace OrcCave
{
    public class GameStatePlaying : IGameState
    {
        Game _gameBase;

        GameStatusBar _gameStatusBar;

        public GameStatePlaying(Game gameBase)
        {
            this._gameBase = gameBase;
            this._gameStatusBar = new GameStatusBar(gameBase);
        }

        public void LoadContent()
        {

        }

        public void UnloadContent()
        {

        }

        public void Updateold()
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
                                IGameState lastGameState = this._gameBase.GameState;
                                this._gameBase.GameState = new GameStatePaused(this._gameBase,lastGameState);
                                break;
                            case SDL.SDL_Keycode.SDLK_RIGHT:
                                this._gameBase.Player.AddCommand(new CharacterCommandMoveRight());
                                break;
                            case SDL.SDL_Keycode.SDLK_LEFT:
                                this._gameBase.Player.AddCommand(new CharacterCommandMoveLeft());
                                break;
                            case SDL.SDL_Keycode.SDLK_UP:
                                this._gameBase.Player.AddCommand(new CharacterCommandMoveUp());
                                break;
                            case SDL.SDL_Keycode.SDLK_DOWN:
                                this._gameBase.Player.AddCommand(new CharacterCommandMoveDown());
                                break;
                            case SDL.SDL_Keycode.SDLK_a:
                                this._gameBase.Player.AddCommand(new CharacterCommandBasicAttack());
                                break;
                            default:
                                this._gameBase.Player.AddCommand(new CharacterCommandIdle());
                                break;
                        }
                        break;
                    default://first switch
                        this._gameBase.Player.AddCommand(new CharacterCommandIdle());
                        break;
                }

            }//while

            //you must change the code, don't use events, try keyborad state
            this._gameBase.Player.AddCommand(new CharacterCommandIdle());
            this._gameBase.Player.Update();
            //this._gameBase.ActualQuest.Update();
            //this._gameStatusBar.Update();

        }

        public void Update()
        {
            this._gameBase.Controller.Update();

            InputState inputState = this._gameBase.Controller.GetInputState();

            if (inputState.Q)
            {
                this._gameBase.GameState = new GameStateQuit(this._gameBase);
            }
            else if (inputState.P)
            {
                IGameState lastGameState = this._gameBase.GameState;
                this._gameBase.GameState = new GameStatePaused(this._gameBase, lastGameState);
            }
            
            this._gameBase.Player.Update();
            this._gameBase.ActualQuest.Update();
            this._gameStatusBar.Update();
        }

        public void Draw()
        {
            IntPtr renderer = _gameBase.Renderer;
            // Clear the screen.
            SDL.SDL_RenderClear(renderer);

            //draw map
            _gameBase.ActualQuest.Draw();
            
            //player layer
            _gameBase.Player.Draw();

            //interfaces
            this._gameStatusBar.Draw();

            // Present the "Painting" (backbuffer) to the screen. Call this once per frame.
            SDL.SDL_RenderPresent(renderer);
        }

    }
}
