using System;
using System.Collections.Generic;
using SDL2;


namespace OrcCave
{
    public interface IQuestLoader
    {
        Quest LoadQuest(int id);
        
    }
}
