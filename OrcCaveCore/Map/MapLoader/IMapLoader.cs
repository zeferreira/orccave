using System;
using System.Collections;
using System.Collections.Generic;
using SDL2;
using IA;

namespace OrcCave
{
    public interface IMapLoader
    {
        Map ReadMapFromFile(string file);
    }
}
