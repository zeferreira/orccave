using System;
using System.Collections.Generic;

namespace OrcCave
{
    public class QuestLoaderTest : IQuestLoader
    {
        public Quest LoadQuest(int id)
        {
            string fileMap = @"Maps\mapTest.txt";

            Quest test = new Quest(0, fileMap);
            
            //lore
            test.Lore = "bla bla bla";

            //load splash art
            //?
            test.LoadContent();

            CharacterBase slime = CharacterUtil.LoadSlimeTest();
            slime.X = test.ActualMap.ObjectiveNode.BasicObject.X;
            slime.Y = test.ActualMap.ObjectiveNode.BasicObject.Y;

            //slime.IACharacterState = new CharacterStateWalking(slime);
            slime.Controller = new ControllerIADoNothing();

            test.ActualEnemyList.Add(slime);

            return test;
        }

    }
}
