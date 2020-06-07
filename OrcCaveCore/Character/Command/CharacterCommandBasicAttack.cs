using System;
using SDL2;

namespace OrcCave
{
    public class CharacterCommandBasicAttack : ICharacterCommand
    {
        private bool _isCanceled = false;
        private bool _isFinished = false;
        private CharacterBase _character;
        private Animation _animation;
        private bool _firstExecution = true;
        bool _isEffectApplied = false;
        
        public override void Update(CharacterBase character)
        {
            if (this._firstExecution)
            {
                this._animation = character.BasicAttackAnimation;
                if (_animation.HasFinished)
                {
                    this._animation.Reset();
                }
            }

            if (this._isCanceled)
            {
                this._isFinished = true;
                this._isCanceled = true;
                this._animation.Reset();
            }
            else
            {
                this._animation = character.BasicAttackAnimation;
                this._character = character;

                this._animation.X = this._character.X;
                this._animation.Y = this._character.Y;
                this._animation.W = this._character.W;
                this._animation.H = this._character.H;

                //this._animation.Update();
                this._isFinished = this._animation.HasFinished;
            }

            this._firstExecution = false;

            //hero
            if (!_isEffectApplied)
            {
                if (character.CharacterType == EnumCharacterType.Hero)
                {
                    foreach (var item in Game.Instance.ActualQuest.ActualEnemyList)
                    {
                        if (character.IsCollision(item))
                        {
                            if (item.Life > 0)
                            {
                                //item.AddCommand(new CharacterCommandTakeDamage(character.Strenght));

                                item.Life -= character.Strenght;
                                this._isEffectApplied = true;
                                //item.ActualAnimation = item.TakeDamageAnimation;
                            }
                        }
                    }
                }

                //enemies
                if (character.CharacterType == EnumCharacterType.Enemy)
                {
                    CharacterBase player = Game.Instance.Player;
                    if (character.IsCollision(player))
                    {
                        if (player.Life > 0)
                        {

                            //player.AddCommand(new CharacterCommandTakeDamage(character.Strenght));
                            player.Life -= character.Strenght;
                            //player.ActualAnimation = player.TakeDamageAnimation;
                        }
                    }
                }

                this._isEffectApplied = true;
            }
            this._animation.Update();
        }

        public override bool HasFinished()
        {
            return this._animation.HasFinished;
        }

        public override void Cancel()
        {
            this._isCanceled = true;
        }

        public override void Draw()
        {
            this._animation.Draw();
        }

        public override bool HasCanceled()
        {
            return false;
        }

        public override bool CanCancel()
        {
            return false;
        }
    }
}
