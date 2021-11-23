using UnityEngine;


namespace Painter 
{
    public class DrawCircle : DrawHandler
    {
        public override bool Check(int x, int y, int size)
        {
            float x2 = Mathf.Pow(x - size / 2, 2);
            float y2 = Mathf.Pow(y - size / 2, 2);
            float r2 = Mathf.Pow(size / 2 - 0.5f, 2);

            if (x2 + y2 < r2)
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

