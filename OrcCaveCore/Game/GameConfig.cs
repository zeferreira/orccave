﻿using System;
using SDL2;

namespace OrcCave
{
    public class GameConfig
    {

        private GameConfig()
        {

        }

        private static readonly object padlock = new object();
        private static GameConfig instance = null;

        public static GameConfig Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new GameConfig();
                    }
                    return instance;
                }
            }
        }

        private int _wresolution, _hresolution;

        public int Wresolution { get => _wresolution; set => _wresolution = value; }
        public int Hresolution { get => _hresolution; set => _hresolution = value; }

        private int _frameRate;
        public int FrameRate { get => _frameRate; set => _frameRate = value; }

        private int _commandQueueCapacity;
        public int CommandQueueCapacity { get => _commandQueueCapacity; set => _commandQueueCapacity = value; }

        private int _moveSpeed;
        public int MoveSpeed { get => _moveSpeed; set => _moveSpeed = value; }

        private int _toleranceCollision;
        public int ToleranceCollision { get => _toleranceCollision; set => _toleranceCollision = value; }

        private string _imageFolder;
        public string ImageFolder { get => _imageFolder; set => _imageFolder = value; }

    }

}
