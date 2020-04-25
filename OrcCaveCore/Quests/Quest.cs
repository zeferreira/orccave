using System;
using System.Collections.Generic;
using SDL2;


namespace OrcCave
{
    public class Quest
    {
        int _id;
        public int ID { get => _id; }

        private string _pathfileMap;
        public string PathfileMap { get => _pathfileMap; set => _pathfileMap = value; }

        string _lore;
        public string Lore { get => _lore; set => _lore = value; }

        private List<CharacterBase> _actualEnemyList;
        public List<CharacterBase> ActualEnemyList { get => _actualEnemyList; set => _actualEnemyList = value; }

        private Map _actualMap;
        public Map ActualMap { get => _actualMap; set => _actualMap = value; }

        private IMapLoader _mapLoader;

        public Quest(int id, string fileMap)
        {
            this._id = id;
            this._pathfileMap = fileMap;
        }

        //public IntPtr ImageSplashArt { get => _imageSplashArt; set => _imageSplashArt = value; }

        public void LoadContent()
        {
            this._mapLoader = new MapLoaderTXT();
            //map
            this._actualMap = this._mapLoader.ReadMapFromFile(@"Maps\mapTest.txt");
            this.ActualEnemyList = new List<CharacterBase>();
        }

        public void Update()
        {
            List<CharacterBase> removed = new List<CharacterBase>();

            foreach (var item in this._actualEnemyList)
            {
                if (item.Life <= 0)
                {
                    removed.Add(item);
                }
                else item.Update();
            }

            foreach (var item in removed)
            {
                this._actualEnemyList.Remove(item);
            }
        }

        public void DrawEnemies()
        {
            foreach (var item in this.ActualEnemyList)
            {
                if (item != null)
                {
                    item.Draw();
                }
            }
        }

    }
}
