using System;
using System.Collections;
using System.Collections.Generic;
using SDL2;
using IA;

namespace OrcCave
{
    public class Map
    {
        //layers
        //floor don't iteract with player
        private MapNode[,] _floor;
        public MapNode[,] FloorLayer { get => _floor; set => _floor = value; }

        private MapNode[,] _walls;
        public MapNode[,] WallsLayer { get => _walls; set => _walls = value; }

        private MapNode _startNode;
        public MapNode StartNode { get => _startNode; set => _startNode = value; }
        
        private MapNode _objectiveNode;
        public MapNode ObjectiveNode { get => _objectiveNode; set => _objectiveNode = value; }

        private string _filePath;

        private IMapLoader _mapReader;

        public Map(/*tring filePath*/)
        {
            //this._filePath = filePath;

            //this._mapReader = new MapLoaderTXT();

            //_floor = this._mapReader.ReadMapFromFile(this._filePath);
        }

        public void Draw()
        {
            DrawFloor();
            DrawWalls();
        }

        public void Update()
        {
            foreach (var item in this.WallsLayer)
            {
                if (item != null)
                {
                    item.Update();
                }
            }

            foreach (var item in this._floor)
            {
                if (item != null)
                {
                    item.Update();
                }
            }
        }


        public List<MapNode> GetSolutionPath(bool reverterOrdem)
        {
            this.CreateGraphFromArray(this._floor);

            IAContext ia = FactoryIAContext.GetIAContext();
            Node root = this.StartNode;
            Node destiny = this.ObjectiveNode;

            MapNode atual = ia.ProcurarCaminhoSolucao(root, destiny) as MapNode;

            List<MapNode> resposta = new List<MapNode>();

            while (atual != null)
            {
                resposta.Add(atual);
                //Console.Write("id: " + atual.identificador);
                //Console.Write(", Coluna: " + atual.coordenadaX);
                //Console.WriteLine(", Linha : " + atual.coordenadaY);
                atual = atual.PreviousNodePath as MapNode;
            }

            if (reverterOrdem)
                resposta.Reverse();

            return resposta;
        }


        #region private_methods
        private void CreateGraphFromArray(MapNode[,] map)
        {
            int MATRIX_ROWS = map.GetLength(0);
            int MATRIX_COLUMNS = map.GetLength(1);

            for (int i = 0; i < MATRIX_ROWS; i++)
            {
                for (int j = 0; j < MATRIX_COLUMNS; j++)
                {
                    MapNode actual = map[i, j];
                    EnumTypeMapNode quadrantType = actual.Type;

                    int indexVizinho = i - 1;
                    if (indexVizinho >= 0 && indexVizinho < MATRIX_ROWS)
                    {
                        MapNode vizinho = map[i - 1, j];
                        if (vizinho.IsWay())
                        {
                            actual.UpNode = vizinho;
                            actual.vizinhos.Add(vizinho);

                            double weight = Distance(actual, this.ObjectiveNode);
                            Edge aresta = new Edge(weight);

                            aresta.PreviousNodePath = actual;
                            aresta.NextNodePath = actual;

                            actual.edgeNeighbors.Add(aresta);
                        }
                    }

                    indexVizinho = j - 1;
                    if (indexVizinho >= 0 && indexVizinho < MATRIX_COLUMNS)
                    {
                        MapNode vizinho = map[i, j - 1];
                        if (vizinho.IsWay())
                        {
                            actual.LeftNode = vizinho;
                            actual.vizinhos.Add(vizinho);

                            double weight = Distance(actual, this.ObjectiveNode);
                            Edge aresta = new Edge(weight);

                            aresta.PreviousNodePath = actual;
                            aresta.NextNodePath = actual;

                            actual.edgeNeighbors.Add(aresta);
                        }
                    }

                    indexVizinho = j + 1;
                    if (indexVizinho >= 0 && indexVizinho < MATRIX_COLUMNS)
                    {
                        MapNode vizinho = map[i, j + 1];
                        if (vizinho.IsWay())
                        {
                            actual.RightNode = vizinho;
                            actual.vizinhos.Add(vizinho);

                            double weight = Distance(actual, this.ObjectiveNode);
                            Edge aresta = new Edge(weight);

                            aresta.PreviousNodePath = actual;
                            aresta.NextNodePath = actual;

                            actual.edgeNeighbors.Add(aresta);
                        }
                    }

                    indexVizinho = i + 1;
                    if (indexVizinho >= 0 && indexVizinho < MATRIX_ROWS)
                    {
                        MapNode vizinho = map[i + 1, j];
                        if (vizinho.IsWay())
                        {
                            actual.DownNode = vizinho;
                            actual.vizinhos.Add(vizinho);

                            double weight = Distance(actual, this.ObjectiveNode);
                            Edge aresta = new Edge(weight);

                            aresta.PreviousNodePath = actual;
                            aresta.NextNodePath = actual;

                            actual.edgeNeighbors.Add(aresta);
                        }
                    }

                    switch (quadrantType)
                    {
                        case EnumTypeMapNode.Wall:
                            break;
                        case EnumTypeMapNode.Way:
                            break;
                        case EnumTypeMapNode.Start:
                            this._startNode = actual;
                            break;
                        case EnumTypeMapNode.Objective:
                            this.ObjectiveNode = actual;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
                
        private double Distance(MapNode point1, MapNode point2)
        {
            double rank = Math.Sqrt((Math.Pow(point1.MapPositionX - point2.MapPositionX, 2) + Math.Pow(point1.MapPositionY- point2.MapPositionY, 2)));

            return rank;
        }

        private void DrawFloor()
        {
            foreach (var item in this._floor)
            {
                if (item != null)
                {
                    item.Draw();
                }
            }
        }

        private void DrawWalls()
        {
            foreach (var item in this._walls)
            {
                if (item != null)
                {
                    item.Draw();
                }
            }
        }
        #endregion private_methods
    }
}
