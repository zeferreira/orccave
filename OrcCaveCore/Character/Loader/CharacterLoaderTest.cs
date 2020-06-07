using System;
using SDL2;

namespace OrcCave
{
    public class CharacterLoaderTest :ICharacterLoader
    {
        public CharacterBase Load()
        {
            return CharacterUtil.LoadHeroTest();
        }

        private CharacterBase LoadDeadKing()
        {
            int contentSpriteID = -1;

            GameObject imageFigSprite = new GameObject(0, 0, 25, 40);
            CharacterBase deadKing = new CharacterBase(imageFigSprite);
            deadKing.CharacterType = EnumCharacterType.Enemy;

            Animation MoveRightAnimation = new Animation(contentSpriteID);

            MoveRightAnimation.Frames.Add(new AnimationFrame(21, 718, 22, 49));
            MoveRightAnimation.Frames.Add(new AnimationFrame(84, 718, 26, 48));
            MoveRightAnimation.Frames.Add(new AnimationFrame(149, 718, 23, 48));
            MoveRightAnimation.Frames.Add(new AnimationFrame(211, 718, 22, 48));
            MoveRightAnimation.Frames.Add(new AnimationFrame(274, 718, 24, 48));
            MoveRightAnimation.Frames.Add(new AnimationFrame(336, 719, 28, 48));
            MoveRightAnimation.Frames.Add(new AnimationFrame(402, 718, 24, 48));
            MoveRightAnimation.Frames.Add(new AnimationFrame(467, 718, 22, 48));
            MoveRightAnimation.Frames.Add(new AnimationFrame(532, 718, 21, 48));

            deadKing.MoveRightAnimation = MoveRightAnimation;

            Animation MoveLeftAnimation = new Animation(contentSpriteID);

            MoveLeftAnimation.Frames.Add(new AnimationFrame(21, 590, 22, 49));
            MoveLeftAnimation.Frames.Add(new AnimationFrame(82, 590, 26, 48));
            MoveLeftAnimation.Frames.Add(new AnimationFrame(148, 590, 23, 48));
            MoveLeftAnimation.Frames.Add(new AnimationFrame(215, 590, 22, 48));
            MoveLeftAnimation.Frames.Add(new AnimationFrame(278, 590, 24, 48));
            MoveLeftAnimation.Frames.Add(new AnimationFrame(340, 591, 28, 48));
            MoveLeftAnimation.Frames.Add(new AnimationFrame(406, 590, 24, 48));
            MoveLeftAnimation.Frames.Add(new AnimationFrame(471, 590, 22, 48));
            MoveLeftAnimation.Frames.Add(new AnimationFrame(535, 590, 21, 48));

            deadKing.MoveLeftAnimation = MoveLeftAnimation;

            Animation MoveUpAnimation = new Animation(contentSpriteID);

            MoveUpAnimation.AddFrame(new AnimationFrame(17, 526, 30, 47));
            MoveUpAnimation.AddFrame(new AnimationFrame(81, 526, 30, 47));
            MoveUpAnimation.Frames.Add(new AnimationFrame(145, 526, 30, 47));
            MoveUpAnimation.Frames.Add(new AnimationFrame(209, 526, 30, 47));
            MoveUpAnimation.Frames.Add(new AnimationFrame(273, 526, 30, 47));
            MoveUpAnimation.AddFrame(new AnimationFrame(337, 526, 30, 47));
            MoveUpAnimation.AddFrame(new AnimationFrame(401, 526, 30, 47));
            MoveUpAnimation.AddFrame(new AnimationFrame(466, 526, 30, 47));
            MoveUpAnimation.AddFrame(new AnimationFrame(529, 526, 30, 47));

            deadKing.MoveUpAnimation = MoveUpAnimation;

            Animation MoveDownAnimation = new Animation(contentSpriteID);

            MoveDownAnimation.AddFrame(new AnimationFrame(17, 654, 30, 47));
            MoveDownAnimation.AddFrame(new AnimationFrame(81, 654, 30, 47));
            MoveDownAnimation.AddFrame(new AnimationFrame(145, 654, 30, 47));
            MoveDownAnimation.AddFrame(new AnimationFrame(209, 654, 30, 47));
            MoveDownAnimation.AddFrame(new AnimationFrame(273, 654, 30, 47));
            MoveDownAnimation.AddFrame(new AnimationFrame(337, 654, 30, 47));
            MoveDownAnimation.AddFrame(new AnimationFrame(401, 654, 30, 47));
            MoveDownAnimation.AddFrame(new AnimationFrame(466, 654, 30, 47));
            MoveDownAnimation.AddFrame(new AnimationFrame(529, 654, 30, 47));

            deadKing.MoveDownAnimation = MoveDownAnimation;

            deadKing.IdleAnimation = MoveDownAnimation;
            deadKing.ActualAnimation = MoveDownAnimation;

            return deadKing;

        }

        private CharacterBase LoadHero()
        {
            int contentSpriteID = 0;

            int tileSize = 32;

            GameObject imageFigSprite = new GameObject(0, 0, tileSize, tileSize);
            CharacterBase currentChar = new CharacterBase(imageFigSprite);

            //basic properties
            currentChar.Name = "Bug Hero";
            currentChar.CharacterType = EnumCharacterType.Hero;
            currentChar.Life = 50;
            currentChar.Strenght = 15;
            currentChar.Gold = 0;

            Animation IdleAnimation = new Animation(contentSpriteID);

            AnimationFrame frameIdle1 = new AnimationFrame(16, 16, 16, 16);
            frameIdle1.FrameTime = 640;

            IdleAnimation.Frames.Add(frameIdle1);

            AnimationFrame frameIdle2 = new AnimationFrame(64, 16, 16, 16);
            frameIdle2.FrameTime = 80;

            IdleAnimation.Frames.Add(frameIdle2);

            AnimationFrame frameIdle3 = new AnimationFrame(112, 16, 16, 16);
            frameIdle3.FrameTime = 640;

            IdleAnimation.Frames.Add(frameIdle3);
            IdleAnimation.Frames.Add(frameIdle2);

            currentChar.IdleAnimation = IdleAnimation;

            Animation MoveRightAnimation = new Animation(contentSpriteID);

            MoveRightAnimation.Frames.Add(new AnimationFrame(16, 161, 16, 16));
            MoveRightAnimation.Frames.Add(new AnimationFrame(66, 161, 16, 16));
            MoveRightAnimation.Frames.Add(new AnimationFrame(113, 161, 16, 16));
            MoveRightAnimation.Frames.Add(new AnimationFrame(162, 161, 16, 16));

            currentChar.MoveRightAnimation = MoveRightAnimation;

            Animation MoveLeftAnimation = new Animation(contentSpriteID);
            MoveLeftAnimation.FlipType = EnumFlipAnimatonType.Horizontal;

            MoveLeftAnimation.Frames.Add(new AnimationFrame(16, 161, 16, 16));
            MoveLeftAnimation.Frames.Add(new AnimationFrame(66, 161, 16, 16));
            MoveLeftAnimation.Frames.Add(new AnimationFrame(113, 161, 16, 16));
            MoveLeftAnimation.Frames.Add(new AnimationFrame(162, 161, 16, 16));

            currentChar.MoveLeftAnimation = MoveLeftAnimation;

            Animation MoveUpAnimation = new Animation(contentSpriteID);

            MoveUpAnimation.Frames.Add(new AnimationFrame(16, 209, 16, 16));
            MoveUpAnimation.Frames.Add(new AnimationFrame(66, 209, 16, 16));
            MoveUpAnimation.Frames.Add(new AnimationFrame(113, 209, 16, 16));
            MoveUpAnimation.Frames.Add(new AnimationFrame(162, 209, 16, 16));

            currentChar.MoveUpAnimation = MoveUpAnimation;

            Animation MoveDownAnimation = new Animation(contentSpriteID);

            MoveDownAnimation.Frames.Add(new AnimationFrame(16, 113, 16, 16));
            MoveDownAnimation.Frames.Add(new AnimationFrame(66, 113, 16, 16));
            MoveDownAnimation.Frames.Add(new AnimationFrame(113, 113, 16, 16));
            MoveDownAnimation.Frames.Add(new AnimationFrame(162, 113, 16, 16));

            currentChar.MoveDownAnimation = MoveDownAnimation;

            Animation BasicAttackAnimation = new Animation(contentSpriteID);

            BasicAttackAnimation.Frames.Add(new AnimationFrame(16, 306, 16, 16,100));
            BasicAttackAnimation.Frames.Add(new AnimationFrame(66, 306, 32, 16, 100));
            BasicAttackAnimation.Frames.Add(new AnimationFrame(114, 306, 32, 16, 100));
            BasicAttackAnimation.Frames.Add(new AnimationFrame(114, 306, 32, 16, 100));
            BasicAttackAnimation.Frames.Add(new AnimationFrame(162, 306, 18, 16, 100));
            BasicAttackAnimation.Frames.Add(new AnimationFrame(162, 306, 18, 16, 100));

            currentChar.BasicAttackAnimation = BasicAttackAnimation;

            Animation TakeDamageAnimation = new Animation(contentSpriteID);

            TakeDamageAnimation.Frames.Add(new AnimationFrame(18, 450, 16, 16));
            TakeDamageAnimation.Frames.Add(new AnimationFrame(66, 450, 16, 16));
            TakeDamageAnimation.Frames.Add(new AnimationFrame(114, 450, 16, 16));
            TakeDamageAnimation.Frames.Add(new AnimationFrame(162, 450, 16, 16));

            currentChar.TakeDamageAnimation = TakeDamageAnimation;

            currentChar.ActualAnimation = IdleAnimation;

            return currentChar;
        }

        public CharacterBase LoadSlime()
        {
            int contentSpriteID = 1;

            int tileSize = 32;

            GameObject imageFigSprite = new GameObject(0, 0, tileSize, tileSize);
            CharacterBase currentChar = new CharacterBase(imageFigSprite);

            //basic properties
            currentChar.Name = "Slime";
            currentChar.CharacterType = EnumCharacterType.Enemy;
            currentChar.Life = 30;
            currentChar.Strenght = 10;
            currentChar.Gold = 10;

            //animations

            Animation IdleAnimation = new Animation(contentSpriteID);

            AnimationFrame frameIdle1 = new AnimationFrame(16, 16, 16, 16);
            frameIdle1.FrameTime = 640;

            IdleAnimation.Frames.Add(frameIdle1);

            AnimationFrame frameIdle2 = new AnimationFrame(64, 16, 16, 16);
            frameIdle2.FrameTime = 80;

            IdleAnimation.Frames.Add(frameIdle2);

            AnimationFrame frameIdle3 = new AnimationFrame(112, 16, 16, 16);
            frameIdle3.FrameTime = 640;

            IdleAnimation.Frames.Add(frameIdle3);
            IdleAnimation.Frames.Add(frameIdle2);

            currentChar.IdleAnimation = IdleAnimation;

            Animation MoveRightAnimation = new Animation(contentSpriteID);

            MoveRightAnimation.Frames.Add(new AnimationFrame(16, 161, 16, 16));
            MoveRightAnimation.Frames.Add(new AnimationFrame(66, 161, 16, 16));
            MoveRightAnimation.Frames.Add(new AnimationFrame(113, 161, 16, 16));
            MoveRightAnimation.Frames.Add(new AnimationFrame(162, 161, 16, 16));

            currentChar.MoveRightAnimation = MoveRightAnimation;

            Animation MoveLeftAnimation = new Animation(contentSpriteID);
            MoveLeftAnimation.FlipType = EnumFlipAnimatonType.Horizontal;

            MoveLeftAnimation.Frames.Add(new AnimationFrame(16, 161, 16, 16));
            MoveLeftAnimation.Frames.Add(new AnimationFrame(66, 161, 16, 16));
            MoveLeftAnimation.Frames.Add(new AnimationFrame(113, 161, 16, 16));
            MoveLeftAnimation.Frames.Add(new AnimationFrame(162, 161, 16, 16));

            currentChar.MoveLeftAnimation = MoveLeftAnimation;

            Animation MoveUpAnimation = new Animation(contentSpriteID);

            MoveUpAnimation.Frames.Add(new AnimationFrame(16, 209, 16, 16));
            MoveUpAnimation.Frames.Add(new AnimationFrame(66, 209, 16, 16));
            MoveUpAnimation.Frames.Add(new AnimationFrame(113, 209, 16, 16));
            MoveUpAnimation.Frames.Add(new AnimationFrame(162, 209, 16, 16));

            currentChar.MoveUpAnimation = MoveUpAnimation;

            Animation MoveDownAnimation = new Animation(contentSpriteID);

            MoveDownAnimation.Frames.Add(new AnimationFrame(16, 113, 16, 16));
            MoveDownAnimation.Frames.Add(new AnimationFrame(66, 113, 16, 16));
            MoveDownAnimation.Frames.Add(new AnimationFrame(113, 113, 16, 16));
            MoveDownAnimation.Frames.Add(new AnimationFrame(162, 113, 16, 16));

            currentChar.MoveDownAnimation = MoveDownAnimation;

            Animation BasicAttackAnimation = new Animation(contentSpriteID);

            BasicAttackAnimation.Frames.Add(new AnimationFrame(16, 306, 16, 16));
            BasicAttackAnimation.Frames.Add(new AnimationFrame(66, 306, 27, 16));
            BasicAttackAnimation.Frames.Add(new AnimationFrame(114, 306, 27, 16));
            BasicAttackAnimation.Frames.Add(new AnimationFrame(162, 306, 18, 16));

            currentChar.BasicAttackAnimation = BasicAttackAnimation;

            Animation TakeDamageAnimation = new Animation(contentSpriteID);

            TakeDamageAnimation.Frames.Add(new AnimationFrame(18, 450, 16, 16));
            TakeDamageAnimation.Frames.Add(new AnimationFrame(66, 450, 16, 16));
            TakeDamageAnimation.Frames.Add(new AnimationFrame(114, 450, 16, 16));
            TakeDamageAnimation.Frames.Add(new AnimationFrame(162, 450, 16, 16));

            currentChar.TakeDamageAnimation = TakeDamageAnimation;

            currentChar.ActualAnimation = IdleAnimation;

            return currentChar;

        }

    }
}
