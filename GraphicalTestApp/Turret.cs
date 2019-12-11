using System;

namespace GraphicalTestApp
{
    class Turret1 : Entity
    {
        private Sprite _turret1 = new Sprite("images/redBarrel.png");

        public Turret1(float x, float y) : base(x, y)
        {
                AddChild(_turret1);
        }

        public void Fire()
        {
            Bullet bullet1 = new Bullet(XAbsolute, YAbsolute);
            bullet1.Rotate(GetRotation());
            bullet1.XVelocity = (float)Math.Cos(GetRotation() - Math.PI * .5f) * 300;
            bullet1.YVelocity = (float)Math.Sin(GetRotation() - Math.PI * .5f) * 300;
            Parent.Parent.AddChild(bullet1);

        }
    }

    class Turret2 : Entity
    {
        private Sprite _turret2 = new Sprite("images/blueBarrel.png");

        public Turret2(float x, float y) : base(x, y)
        {
            AddChild(_turret2);
        }

        public void Fire()
        {
            Bullet bullet = new Bullet(XAbsolute, YAbsolute);
            bullet.Rotate(GetRotation());
            bullet.XVelocity = (float)Math.Cos(GetRotation() - Math.PI * .5f) * 300;
            bullet.YVelocity = (float)Math.Sin(GetRotation() - Math.PI * .5f) * 300;
            Parent.Parent.AddChild(bullet);

        }
    }
}
