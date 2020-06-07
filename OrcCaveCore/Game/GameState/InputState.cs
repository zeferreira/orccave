using System;
using SDL2;

namespace OrcCave
{
    public class InputState
    {
        //Console buttons 
        private bool _p;
        private bool _q;
        private bool _a;
        private bool _right;
        private bool _left;
        private bool _up;
        private bool _down;
        
        public bool P { get => _p; set => _p = value; }
        public bool Q { get => _q; set => _q = value; }
        public bool A { get => _a; set => _a = value; }
        public bool Right { get => _right; set => _right = value; }
        public bool Left { get => _left; set => _left = value; }
        public bool Up { get => _up; set => _up = value; }
        public bool Down { get => _down; set => _down = value; }

        public bool HasInput()
        {
            if (P || Q || A || Right || Left || Up || Down)
                return true;
            else return false;
        }
    }

}
