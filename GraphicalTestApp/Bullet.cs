using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Bullet : Entity
    {
        public Sprite _bSprite;
        public AABB _bHitbox;

        public float playerNum;
        public Bullet(float x, float y, float p, string _bulletSprite) : base(x, y)
        {
            playerNum = p;
            X = x;
            Y = y;

            Sprite bulletSprite = new Sprite(_bulletSprite);
            AABB bulletHitBox = new AABB(bulletSprite.Height, bulletSprite.Width);

            _bSprite = bulletSprite;
            _bHitbox = bulletHitBox;

            AddChild(bulletSprite);
            AddChild(bulletHitBox);
        }

        //checks to see if a givin value is with a givin min and max
        public bool inRange(float val, float min, float max)
        {
            if (val > min && val < max)
            {
                return true;
            }
            return false;
        }

        //make sure the bullet is on screen
        public void checkBulletPosition()
        {
            if (inRange(X, 0, 1280) == false || inRange(Y, 0, 760) == false)
            {
                Parent.RemoveChild(this);
            }
        }
        
        //destroys tank if hit buy opponents bullet
        public void tankOnBulletCollision(float deltaTime)
        {
            foreach (Tank t in Tank.PlayerList)
            {
                if (playerNum != t.getPlayerNum())
                {
                    if (_bHitbox.DetectCollision(t.getTankHitbox()) == true)
                    {
                        Parent.RemoveChild(t);
                        Parent.RemoveChild(this);
                    }
                }
            }
        }

        //destroys bullets when they hit each other
        public virtual void bulletOnBulletCollision(float deltaTime)
        {
            Actor Root = Parent as Actor;
            foreach (Actor b in Root.GetChildren())
            {
                if (b == this)
                {
                    return;
                }
                if (b is Bullet)
                {
                    Bullet bullet = b as Bullet;
                    if (_bHitbox.DetectCollision(bullet._bHitbox) == true)
                    {
                        Parent.RemoveChild(b);
                        Parent.RemoveChild(this);
                    }
                }
            }
        }

        //update every second
        public override void Update(float deltaTime)
        {
            checkBulletPosition();
            base.Update(deltaTime);
            tankOnBulletCollision(deltaTime);
            bulletOnBulletCollision(deltaTime);
        }
    }
}
