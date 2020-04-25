using System;
using System.Collections.Generic;


namespace OrcCave
{
    public class CharacterBase : BasicObject
    {
        //IA
        private ICharacterState _IACharacterState;
        public ICharacterState IACharacterState { get => _IACharacterState; set => _IACharacterState = value; }

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

        GameConfig _config;

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


        private CharacterStatusBar _statusBar;

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

        public CharacterBase(BasicObject basicObject)
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
            if (this._actualCommand.HasFinished())
            {
                if ((this.Life > 0) && this._commandQueue.Count < this._commandQueueCapacity)
                {
                    if (this._lastEnqueueCommand == null)
                    {
                        this._commandQueue.Enqueue(command);
                        this._lastEnqueueCommand = command;
                    }
                    //else if (!(_lastEnqueueCommand.GetType() == command.GetType() ))
                    else if ((_lastEnqueueCommand is CharacterCommandIdle) && (command is CharacterCommandIdle) && (_commandQueue.Count > 0))
                    { }
                    else
                    {
                        //Console.WriteLine("opa!!");
                        this._commandQueue.Enqueue(command);
                        this._lastEnqueueCommand = command;
                    }
                }
            }
        }
        
        public override void Draw()
        {
            base.Draw();
            this._statusBar.Draw();
        }

        public void Update()
        {
            //controlado pela IA (FSM)
            if (this._IACharacterState != null)
            {
                this._IACharacterState.Update();
            }
            
            if (this._actualCommand.HasFinished())
            {
                if(this._commandQueue.Count > 0)
                {
                    this._actualCommand = this._commandQueue.Dequeue();
                    this._actualCommand.Execute(this);
                }
            }
            this._statusBar.Update();
            this.ActualAnimation.Update();
        }
    }
}
