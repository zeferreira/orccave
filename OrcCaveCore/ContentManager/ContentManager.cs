using System;
using System.Collections;
using System.Collections.Generic;
using SDL2;

namespace OrcCave
{
    public class ContentManager
    {
        private Dictionary<int, IntPtr> _images;

        public ContentManager()
        {
            this._images = new Dictionary<int, IntPtr>();
        }

        public IntPtr GetImage(int id)
        {
            return this._images[id];
        }

        public void AddImage(int id, IntPtr texture)
        {
            this._images.Add(id, texture);
        }
    }
}
