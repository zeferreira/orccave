using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using SDL2;
using Util;

namespace OrcCave
{
    public class ContentManagerLoader
    {
        private FileSystemHelper _fileHelper;
        private string _contentFolder;

        public ContentManagerLoader(GameConfig config)
        {
            this._contentFolder = config.ImageFolder; 
            this._fileHelper = new FileSystemHelper();
        }

        public SpriteSheetContentManager LoadContent()
        {
            SpriteSheetContentManager result = new SpriteSheetContentManager();

            List<string> files = this._fileHelper.ReadFiles(_contentFolder);

            foreach (var item in files)
            {
                
                int id = Convert.ToInt32(Path.GetFileNameWithoutExtension(item));

                SpriteSheet sheet = new SpriteSheet(id, item);
                result.Add(id,sheet);
            }

            return result;
        }
    }
}
