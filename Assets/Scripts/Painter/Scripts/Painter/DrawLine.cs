using UnityEngine;


namespace Painter 
{
    public class DrawLine : DrawHandler
    {
        public override bool Check(int x, int y, int size)
        {
            if (x >= size/2-5 && x <= size/2+5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

