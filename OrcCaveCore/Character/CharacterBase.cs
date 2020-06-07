using System;
using System.Collections.Generic;


namespace OrcCave
{
    public class CharacterBase : GameObject
    {
        //general configuration
        GameConfig _config;

        //gui
        private CharacterStatusBar _statusBar;
        
        //IA
        private ICharacterState _IACharacterState;
        public ICharacterState IACharacterState { get => _IACharacterState; set => _IACharacterState = value; }

        IController _controller;
        public IController Controller { get => _controller; set => _controller = value; }

        //basic properties
        string _name;
        public string Name { get => _name; set => _name = value; }

        int _level;

        int _life;
        public int Life { get => _life; set => _life = value; }

        int _strenght;
        public int Strenght { get => _strenght; set => _strenght = value; }
        
        int _constitution;
        int _dexterity;
        int _inteligence;

        int _gold;
        public int Gold { get => _gold; set => _gold = value; }

        private EnumCharacterType _characterType;
        public EnumCharacterType CharacterType { get => _characterType; set => _characterType = value; }

        //command 
        private int _commandQueueCapacity;
        private Queue<ICharacterCommand> _commandQueue;
        
        private ICharacterCommand _actualCommand;

        private ICharacterCommand _lastEnqueueCommand;
        //command end

        
        //animation system start
        Animation _moveRightAnimation;
        public Animation MoveRightAnimation { get => _moveRightAnimation; set => _moveRightAnimation = value; }

        Animation _moveLeftAnimation;
        public Animation MoveLeftAnimation { get => _moveLeftAnimation; set => _moveLeftAnimation = value; }

        Animation _moveUpAnimation;
        public Animation MoveUpAnimation { get => _moveUpAnimation; set => _moveUpAnimation = value; }

        Animation _moveDownAnimation;
        public Animation MoveDownAnimation { get => _moveDownAnimation; set => _moveDownAnimation = value; }

        private Animation _idleAnimation;
        public Animation IdleAnimation { get => _idleAnimation; set => _idleAnimation = value; }

        private Animation _basicAttackAnimation;
        public Animation BasicAttackAnimation { get => _basicAttackAnimation; set => _basicAttackAnimation = value; }

        private Animation _takeDamageAnimation;
        public Animation TakeDamageAnimation { get => _takeDamageAnimation; set => _takeDamageAnimation = value; }
        
        //animation system end

        public CharacterBase(int x, int y, int w, int h)
            :base(x,y,w,h)
        {
            this._config = GameConfig.Instance;

            this._commandQueueCapacity = _config.CommandQueueCapacity;
            this._commandQueue = new Queue<ICharacterCommand>();

            this.RightVelocity = 0;
            this.LeftVelocity = 0;
            this.DownVelocity = 0;
            this.UpVelocity = 0;
            this.VelocityIncrement = GameConfig.Instance.MoveSpeed;

            this._statusBar = new CharacterStatusBar(this, x+10, y-10);
        }

        public CharacterBase(GameObject basicObject)
            : base(basicObject.X, basicObject.Y, basicObject.W, basicObject.H)
        {
            this._config = GameConfig.Instance;

            this._commandQueueCapacity = _config.CommandQueueCapacity;
            this._commandQueue = new Queue<ICharacterCommand>();
            this._actualCommand = new CharacterCommandIdle();

            this.RightVelocity = 0;
            this.LeftVelocity = 0;
            this.DownVelocity = 0;
            this.UpVelocity = 0;
            this.VelocityIncrement = GameConfig.Instance.MoveSpeed;

            this._statusBar = new CharacterStatusBar(this, basicObject.X + 10, basicObject.Y - 10);
        }


        public void AddCommand(ICharacterCommand command)
        {
            //characters life 
            if ((this.Life > 0))
            {
                if (this._actualCommand.HasFinished() || this._actualCommand.CanCancel())
                {
                    if (!(this._actualCommand is CharacterCommandIdle))
                    {
                        this._actualCommand = command;
                    }
                    else if(this._actualCommand.HasFinished())
                    {
                        this._actualCommand = command;
                    }
                }
            }
        }

        public void Draw()
        {
            this._actualCommand.Draw();
            this._statusBar.Draw();
        }

        public void Update()
        {
            //controlado pela IA (FSM)
            if (this._IACharacterState != null)
            {
                this._IACharacterState.Update();
            }
            
            //controlado pelo jogador
            bool hasUserInput = this.Controller.GetInputState().HasInput();

            if (hasUserInput)
            {
                if (this._actualCommand.HasFinished() || this._actualCommand.CanCancel())
                {
                    this._actualCommand = this.Controller.GetCommand();
                }
            }
            else if(this._actualCommand.HasFinished() || this._actualCommand == null)
            {
                this._actualCommand = new CharacterCommandIdle();
            }

            //Foggy, I may need to separate game status buttons from character command buttons
            if (this._actualCommand == null)
            {
                this._actualCommand = new CharacterCommandIdle();
            }

            this._actualCommand.Update(this);
            this._statusBar.Update();
        }
    }
}
