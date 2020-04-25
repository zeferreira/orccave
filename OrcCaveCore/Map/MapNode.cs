using System;
using System.Collections;
using System.Collections.Generic;
using SDL2;
using IA;

namespace OrcCave
{
    public class MapNode : Node
    {
        private EnumTypeMapNode type;
        public EnumTypeMapNode Type { get => type; set => type = value; }

        private BasicObject _basicObject;
        public BasicObject BasicObject { get => _basicObject; set => _basicObject = value; }

        private MapNode _rightNode;
        public MapNode RightNode { get => _rightNode; set => _rightNode = value; }

        private MapNode _leftNode;
        public MapNode LeftNode { get => _leftNode; set => _leftNode = value; }

        private MapNode _upNode;
        public MapNode UpNode { get => _upNode; set => _upNode = value; }

        private MapNode _downNode;
        public MapNode DownNode { get => _downNode; set => _downNode = value; }

        private int _mapPositionX;
        public int MapPositionX { get => _mapPositionX; set => _mapPositionX = value; }

        private int _mapPositionY;
        public int MapPositionY { get => _mapPositionY; set => _mapPositionY = value; }


        public MapNode() : base()
        { }

        public bool IsWay()
        {
            bool isWay = false;

            switch (this.Type)
            {
                case EnumTypeMapNode.Wall:
                    break;
                case EnumTypeMapNode.Way:
                    isWay= true;
                    break;
                case EnumTypeMapNode.Start:
                    isWay = true;
                    break;
                case EnumTypeMapNode.Objective:
                    isWay = true;
                    break;
                default:
                    break;
            }

            return isWay;
        }
    }
}
