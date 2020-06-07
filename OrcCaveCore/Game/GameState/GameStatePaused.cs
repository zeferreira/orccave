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
            this._gameBase.Controller.Update();

            InputState inputState = this._gameBase.Controller.GetInputState();

            if (inputState.Q)
            {
                this._gameBase.GameState = new GameStateQuit(this._gameBase);
            }
            else if (inputState.P)
            {
                this._gameBase.GameTime.StartClock();
                this._gameBase.GameState = _lastGamePlaingState;
            }
                        
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
