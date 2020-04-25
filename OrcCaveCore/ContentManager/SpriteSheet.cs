using System;
using System.Collections;
using System.Collections.Generic;
using SDL2;
using Util;

namespace OrcCave
{
    public class SpriteSheet
    {
        int _id;
        public int ID { get => _id; set => _id = value; }

        string _filePath;
        public string FilePath { get => _filePath; set => _filePath = value; }

        private IntPtr _contentImage;
        public IntPtr ContentImage { get => _contentImage; set => _contentImage = value; }

        private IntPtr _texture;
        public IntPtr Texture { get => _texture; set => _texture = value; }

        public SpriteSheet(int id, string filePath)
        {
            this.ID = id;
            this._filePath = filePath;

            this.ContentImage = SDL_image.IMG_Load(this._filePath);
            this.Texture = SDL.SDL_CreateTextureFromSurface(Game.Instance.Renderer, ContentImage);
        }
        //"dead_king.png"
        //public List<SpriteSheet> ListFromFolder(string path)
        //{
        //    List<SpriteSheet> prites

        //    FileSystemHelper fileHelper = new FileSystemHelper();

        //    List<string> files = fileHelper.ReadFiles(string path);

        //    foreach (var item in files)
        //    {
        //        SpriteSheet sprite = new SpriteSheet
        //    }
        //}
    }
}
