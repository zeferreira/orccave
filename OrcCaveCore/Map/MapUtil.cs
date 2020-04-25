using System;
using System.Collections;
using System.Collections.Generic;
using SDL2;
using IA;

namespace OrcCave
{
    public class MapUtil 
    {
        public static AnimationFrame GetFloorFrame(int i)
        {
            List<AnimationFrame> frames = new List<AnimationFrame>();

            AnimationFrame frameFloor1 = new AnimationFrame(32, 0, 16, 16);
            frameFloor1.FrameTime = 100;

            frames.Add(frameFloor1);

            //return frames[i];

            return frameFloor1;
        }

        public static AnimationFrame GetWallFrame(int i)
        {
            List<AnimationFrame> frames = new List<AnimationFrame>();

            AnimationFrame frameWall1 = new AnimationFrame(0, 128, 16, 16);
            frameWall1.FrameTime = 100;

            frames.Add(frameWall1);

            //return frames[i];
            return frameWall1;
        }


    }
}
