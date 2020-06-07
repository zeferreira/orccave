using System;
using System.Collections;
using System.Collections.Generic;
using SDL2;
using IA;
using System.IO;

namespace OrcCave
{
    public class MapLoaderTXT : IMapLoader
    {
        Map _result;

        public Map ReadMapFromFile(string file)
        {
            this._result = ReadLayerFromFile(file);

            return this._result;
        }

        private Map ReadLayerFromFile(string file)
        {
            this._result = new Map();
            int input;

            string[] lines = File.ReadAllLines(file);

            int MATRIX_ROWS = lines.Length;
            int MATRIX_COLUMNS = lines[0].Length;

            int identificadorCount = 0;

            MapNode[,] layerFloor = new MapNode[MATRIX_ROWS, MATRIX_COLUMNS];
            MapNode[,] layerWalls = new MapNode[MATRIX_ROWS, MATRIX_COLUMNS];

            for (int i = 0; i < MATRIX_ROWS; i++)
            {
                for (int j = 0; j < MATRIX_COLUMNS; j++)
                {
                    MapNode quadranteAtual = new MapNode();
                    quadranteAtual.identificador = identificadorCount;

                    if (!int.TryParse((lines[i][j].ToString()), out input))
                    {
                        throw new Exception("Enter correct value for ({i},{j}): " + i.ToString() + " , " + j.ToString());
                    }

                    EnumTypeMapNode quadranteTipo = (EnumTypeMapNode)input;
                    quadranteAtual.Type = quadranteTipo;

                    quadranteAtual.MapPositionX = j;
                    quadranteAtual.MapPositionY = i;

                    identificadorCount++;

                    switch (quadranteTipo)
                    {
                        case EnumTypeMapNode.Wall:
                            layerWalls[i, j] = quadranteAtual;
                            break;
                        case EnumTypeMapNode.Way:
                            layerFloor[i, j] = quadranteAtual;
                            break;
                        case EnumTypeMapNode.Start:
                            layerFloor[i, j] = quadranteAtual;
                            this._result.StartNode = quadranteAtual;
                            break;
                        case EnumTypeMapNode.Objective:
                            layerFloor[i, j] = quadranteAtual;
                            this._result.ObjectiveNode = quadranteAtual;
                            break;
                        default:
                            break;
                    }

                    quadranteAtual.BasicObject = GetBasicObject(quadranteAtual, input);
                    quadranteAtual.Animation = quadranteAtual.BasicObject.ActualAnimation;
                }
            }

            this._result.FloorLayer = layerFloor;
            this._result.WallsLayer = layerWalls;

            return this._result;
        }

        private GameObject GetBasicObject(MapNode node, int inputType)
        {
            int contentSpriteID = 2;

            int tileSize = 32;

            GameObject imageFigSprite = new GameObject(node.MapPositionX * tileSize, node.MapPositionY * tileSize, tileSize, tileSize);

            Animation ActualAnimation = new Animation(contentSpriteID);

            switch (node.Type)
            {
                case EnumTypeMapNode.Wall:
                    ActualAnimation.AddFrame(MapUtil.GetWallFrame(inputType));
                    break;
                case EnumTypeMapNode.Way:
                    ActualAnimation.AddFrame(MapUtil.GetFloorFrame(inputType));
                    break;
                case EnumTypeMapNode.Start:
                    ActualAnimation.AddFrame(MapUtil.GetFloorFrame(inputType));
                    break;
                case EnumTypeMapNode.Objective:
                    ActualAnimation.AddFrame(MapUtil.GetFloorFrame(inputType));
                    break;
                default:
                    break;
            }

            imageFigSprite.ActualAnimation = ActualAnimation;

            return imageFigSprite;
        }
    }
}
