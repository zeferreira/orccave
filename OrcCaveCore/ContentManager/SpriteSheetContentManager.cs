using System;
using System.Collections;
using System.Collections.Generic;
using SDL2;

namespace OrcCave
{
    public class SpriteSheetContentManager
    {
        private Dictionary<int, SpriteSheet> _spriteSheetList;

        public SpriteSheetContentManager()
        {
            this._spriteSheetList = new Dictionary<int, SpriteSheet>();
        }

        public SpriteSheet GetSpriteSheet(int id)
        {
            return this._spriteSheetList[id];
        }

        public void Add(int id, SpriteSheet spriteSheet)
        {
            this._spriteSheetList.Add(id, spriteSheet);
        }

        public bool Exist(int id)
        {
            if (this._spriteSheetList.ContainsKey(id))
            {
                return true;
            }
            else return false;
        }
    }
}
