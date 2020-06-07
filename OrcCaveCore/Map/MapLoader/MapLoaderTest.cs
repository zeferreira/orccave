using System;
using System.Collections;
using System.Collections.Generic;
using SDL2;
using IA;
using System.IO;

namespace OrcCave
{
    public class MapLoaderTest : IMapLoader
    {
        Map _result;

        public Map ReadMapFromFile(string file)
        {
            this._result = new Map();

            this._result.FloorLayer = ReadLayerFromFile(file);

            return this._result;
            //throw new NotImplementedException();
        }

        private MapNode[,] ReadLayerFromFile(string file)
        {
            MapNode _startNode;
            MapNode _objectiveNode;

            string[] lines = File.ReadAllLines(file);

            int MATRIX_ROWS = lines.Length;
            int MATRIX_COLUMNS = lines[0].Length;

            int identificadorCount = 0;

            MapNode[,] layer = new MapNode[MATRIX_ROWS, MATRIX_COLUMNS];

            for (int i = 0; i < MATRIX_ROWS; i++)
            {
                for (int j = 0; j < MATRIX_COLUMNS; j++)
                {
                    MapNode quadranteAtual = new MapNode();
                    quadranteAtual.identificador = identificadorCount;

                    int input;

                    if (!int.TryParse((lines[i][j].ToString()), out input))
                    {
                        throw new Exception("Enter correct value for ({i},{j}): " + i.ToString() + " , " + j.ToString());
                    }

                    EnumTypeMapNode quadranteTipo = (EnumTypeMapNode)input;
                    quadranteAtual.Type = quadranteTipo;

                    quadranteAtual.MapPositionX = j;
                    quadranteAtual.MapPositionY = i;

                    layer[i, j] = quadranteAtual;
                    identificadorCount++;

                    switch (quadranteTipo)
                    {
                        case EnumTypeMapNode.Wall:
                            break;
                        case EnumTypeMapNode.Way:
                            break;
                        case EnumTypeMapNode.Start:
                            _startNode = quadranteAtual;
                            break;
                        case EnumTypeMapNode.Objective:
                            _objectiveNode = quadranteAtual;
                            break;
                        default:
                            break;
                    }

                    quadranteAtual.BasicObject = GetBasicObject(quadranteAtual);
                }
            }

            return layer;
        }
        
        private GameObject GetBasicObject(MapNode node)
        {
            int contentSpriteID = 2;

            int tileSize = 32;

            GameObject imageFigSprite = new GameObject(node.MapPositionX*tileSize, node.MapPositionY * tileSize, tileSize, tileSize);


            Animation ActualAnimation = new Animation(contentSpriteID);

            AnimationFrame frameFloor1 = new AnimationFrame(32, 0, 16, 16);
            frameFloor1.FrameTime = 100;

            ActualAnimation.Frames.Add(frameFloor1);

            imageFigSprite.ActualAnimation = ActualAnimation;

            return imageFigSprite;
        }
    }


}
