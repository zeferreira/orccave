using SDL2;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OrcCave
{
    public class ControllerIADoNothing : IController
    {
        ICharacterCommand _command;
        InputState _inputState;

        public ControllerIADoNothing()
        {
            this._inputState = new InputState();
        }

        public InputState GetInputState()
        {
            return this._inputState;
        }

        public void Update()
        {
            //this._inputState = GetInputFromPool();

            //if (!this._inputState.HasInput())
            //{
            //    this._command = new CharacterCommandIdle();
            //}
            if (this._inputState.Right)
            {
                this._command = new CharacterCommandMoveRight();
            }
            else if (this._inputState.Left)
            {
                this._command = new CharacterCommandMoveLeft();
            }
            else if (this._inputState.Up)
            {
                this._command = new CharacterCommandMoveUp();
            }
            else if (this._inputState.Down)
            {
                this._command = new CharacterCommandMoveDown();
            }
            else if (this._inputState.A)
            {
                this._command = new CharacterCommandBasicAttack();
            }
            //else
            //    throw new Exception("No command");
        }

        public ICharacterCommand GetCommand()
        {
            return new CharacterCommandIdle();
            //return this._command;
        }

        private static byte[] GetNewKeyboardState()
        {
            int _numkeys;

            IntPtr _keysBuffer;

            byte[] state = new byte[(int)SDL.SDL_Scancode.SDL_NUM_SCANCODES];

            // called once, to get buffer pointer
            _keysBuffer = SDL.SDL_GetKeyboardState(out _numkeys);

            // update keyboard state each frame
            SDL.SDL_PumpEvents();

            // copy new state
            Marshal.Copy(_keysBuffer, state, 0, _numkeys);

            return state;
        }

        private InputState ConvertArrayToInputState(byte[] state)
        {
            InputState input = new InputState();

            if (state[(int)SDL.SDL_Scancode.SDL_SCANCODE_RIGHT] != 0)
            {
                input.Right = true;
            }
            else if (state[(int)SDL.SDL_Scancode.SDL_SCANCODE_LEFT] != 0)
            {
                input.Left = true;
            }
            else if (state[(int)SDL.SDL_Scancode.SDL_SCANCODE_UP] != 0)
            {
                input.Up = true;
            }
            else if (state[(int)SDL.SDL_Scancode.SDL_SCANCODE_DOWN] != 0)
            {
                input.Down = true;
            }
            else if (state[(int)SDL.SDL_Scancode.SDL_SCANCODE_A] != 0)
            {
                input.A = true;
            }
            else if (state[(int)SDL.SDL_Scancode.SDL_SCANCODE_P] != 0)
            {
                input.P = true;
            }
            else if (state[(int)SDL.SDL_Scancode.SDL_SCANCODE_Q] != 0)
            {
                input.Q = true;
            }
            else if (state[(int)SDL.SDL_Scancode.SDL_SCANCODE_ESCAPE] != 0)
            {
                input.Q = true;
            }

            return input;
        }

        private InputState GetInputFromPool()
        {
            InputState result = new InputState();

            SDL.SDL_Event e;

            while (SDL.SDL_PollEvent(out e) != 0)
            {
                switch (e.type)
                {
                    case SDL.SDL_EventType.SDL_QUIT:
                        result.Q = true;
                        break;
                    case SDL.SDL_EventType.SDL_KEYDOWN:
                        switch (e.key.keysym.sym)
                        {
                            case SDL.SDL_Keycode.SDLK_q:
                                result.Q = true;
                                break;
                            case SDL.SDL_Keycode.SDLK_ESCAPE:
                                result.Q = true;
                                break;
                            case SDL.SDL_Keycode.SDLK_p:
                                result.P = true;
                                break;
                            case SDL.SDL_Keycode.SDLK_RIGHT:
                                result.Right = true;
                                break;
                            case SDL.SDL_Keycode.SDLK_LEFT:
                                result.Left = true;
                                break;
                            case SDL.SDL_Keycode.SDLK_UP:
                                result.Up = true;
                                break;
                            case SDL.SDL_Keycode.SDLK_DOWN:
                                result.Down = true;
                                break;
                            case SDL.SDL_Keycode.SDLK_a:
                                result.A = true;
                                break;
                            default:
                                //
                                break;
                        }
                        break;
                    default://first switch
                        //
                        break;
                }

            }//while

            return result;
        }
    }
}
