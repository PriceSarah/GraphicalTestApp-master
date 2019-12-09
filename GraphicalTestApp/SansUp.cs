using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class SansUp : Barrel
    {
        Sprite _bSprite;
        AABB _bHitbox;

        //replace barrel
        public SansUp(float x, float y, string _barrelSprite) : base(x, y)
        {
            Sprite barrelSprite = new Sprite(_barrelSprite);
            AABB barrelHitBox = new AABB(barrelSprite.Height, barrelSprite.Width);

            _bSprite = barrelSprite;
            _bHitbox = barrelHitBox;

            X = x;
            Y = y;
            Rotate((float)Math.PI);
        }

        //creates bullet and sends it in the direction the barrel is facing
        public override void Fire()
        {
            if (Parent is Tank)
            {
                Tank player = Parent as Tank;
                Bullet bullet = new Bullet(XAbsolute, YAbsolute, player.getPlayerNum(), "Bone44x12.png");

                Parent.Parent.AddChild(bullet);
                bullet.SetRotate(GetRotation() + (float)Math.PI);
                bullet.XVelocity = (float)Math.Cos(bullet.GetRotation() - (float)Math.PI * 0.5f) * 100;
                bullet.YVelocity = (float)Math.Sin(bullet.GetRotation() - (float)Math.PI * 0.5f) * 100;
            }
        }

        //p1 barrel controls
        public override void p1BarrelConrols(float deltaTime)
        {
            //q
            if (Input.IsKeyDown(81))
            {
                //rotate left
                Rotate((float)-Math.PI / 6 * deltaTime * 20);
            }
            //e (nice)
            if (Input.IsKeyDown(69))
            {
                //rotate right
                Rotate((float)Math.PI / 6 * deltaTime * 20);
            }
            //space
            if (Input.IsKeyDown(32))
            {
                //shoot bullet
                Fire();
            }
        }

        //p2 barrel controls
        public override void p2BarrelConrols(float deltaTime)
        {
            //7 keypad
            if (Input.IsKeyDown(327))
            {
                //rotate left
                Rotate((float)-Math.PI / 6 * deltaTime * 20);
            }
            //9 keypad
            if (Input.IsKeyDown(329))
            {
                //rotate right
                Rotate((float)Math.PI / 6 * deltaTime * 20);
            }
            //0 keypad
            if (Input.IsKeyDown(320))
            {
                //shoot bullet
                Fire();
            }
        }
    }
}
