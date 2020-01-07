
using System;
namespace GraphicalTestApp
{
    class AABB : Actor
    {
        public float Width { get; set; } = 1;
        public float Height { get; set; } = 1;
        public static bool canDrawHitbox = true;
        private Vector3 _min = new Vector3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);
        private Vector3 _max = new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);

        Raylib.Color color = Raylib.Color.BLUE;

        //Returns the Y coordinate at the top of the box
        public float Top
        {
            get { return YAbsolute - Height / 2; }
        }

        //Returns the Y coordinate at the top of the box
        public float Bottom
        {
            get { return YAbsolute + Height / 2; }
        }

        //Returns the X coordinate at the top of the box
        public float Left
        {
            get { return XAbsolute - Width / 2; }
        }

        //Returns the X coordinate at the top of the box
        public float Right
        {
            get { return XAbsolute + Width / 2; }
        }

        //Creates an AABB of the specifed size
        public AABB(float width, float height)
        {
            Width = width;
            Height = height;
            X = 0;
            Y = 0;
        }

        public bool DetectCollision(AABB other)
        {
            //test for overlapped as it exists faster
            if (Right >= other.Left && Bottom >= other.Top && Left <= other.Right && Top <= other.Bottom)
            {
                color = Raylib.Color.BLUE;
                return true;
            }
            color = Raylib.Color.RED;
            return false;
        }

        public bool DetectCollision(Vector3 point)
        {
            //test for overlapped as it exists faster
            return !(point.x < Bottom || point.y < Left || point.x > Right || point.y > Top);
        }

        public void HitBox()
        {
            if (canDrawHitbox == true)
            {
                Raylib.Rectangle rec = new Raylib.Rectangle(Left, Top, Width, Height);
                Raylib.Raylib.DrawRectangleLinesEx(rec, 5, color);
            }
            if (canDrawHitbox == false)
            {
                return;
            }
        }


        //Draw the bounding box to the screen
        public override void Draw()
        {
            HitBox();
            base.Draw();
        }
    }
}
