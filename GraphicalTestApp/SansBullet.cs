using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class SansBullet : Bullet
    {
        Sprite _bSprite;
        AABB _bHitbox;

        public float playerNum;
        public SansBullet(float x, float y, float p, string _bulletSprite) : base(x, y, p, _bulletSprite)
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

        //destroys opponents bullets if they hit sansbullet
        public override void bulletOnBulletCollision(float deltaTime)
        {
            Actor Root = Parent as Actor;
            foreach (Actor b in Root.GetChildren())
            {
                
                if (b is Bullet)
                {
                    Bullet bullet = b as Bullet;
                    if (bullet.playerNum == this.playerNum)
                    {
                        return;
                    }
                    if (_bHitbox.DetectCollision(bullet._bHitbox) == true)
                    {
                        Parent.RemoveChild(b);
                        Parent.RemoveChild(this);
                    }
                }
            }
        }
    }
}
