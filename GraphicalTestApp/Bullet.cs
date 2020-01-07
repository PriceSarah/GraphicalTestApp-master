using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Bullet : Entity
    {
        private Sprite _bulletSprite = new Sprite("images/bullet.png");
        private AABB _hitbox;

        public Bullet(float x, float y) : base(x, y)
        {
            X = x;
            Y = y;

            AABB hitbox = new AABB(_bulletSprite.Width, _bulletSprite.Height);
            hitbox.X += 0;
            hitbox.Y += 0;

            _hitbox = hitbox;

            AddChild(hitbox);
            AddChild(_bulletSprite);

            OnUpdate += BulletCollision;
        }


        private void BulletCollision(float deltaTime)
        {
            if (_hitbox.DetectCollision(Player1.player1.hitbox))
            {
                Parent.RemoveChild(this);
            }
            else if (_hitbox.DetectCollision(Player2.player2.hitbox))
            {
                Parent.RemoveChild(this);
            }
        }
    }
}
