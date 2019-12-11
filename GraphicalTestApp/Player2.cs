using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Player2 : Entity
    {
        private Sprite _playerSprite = new Sprite("images/blueBody.png");

        public AABB hitbox;

        public Player2(float x, float y) : base(x, y)
        {
            //Sets up the player
            X = x;
            Y = y;

            //Sets up the hitbox
            AABB Hitbox = new AABB(_playerSprite.Width, _playerSprite.Height);
            hitbox = Hitbox;

            hitbox.X = 0;
            hitbox.Y = 0;

            //Adding all children
            AddChild(_playerSprite);
            AddChild(hitbox);

            //Updating everything
            OnUpdate += Movement;
            OnUpdate += Rotation;
            OnUpdate += bounceCheck;
        }

        public AABB Hitbox()
        {
            return hitbox;
        }

        private void Movement(float deltaTime)
        {

            //Move forward with 8
            if (Input.IsKeyDown(328))
            {
                XAcceleration = (float)Math.Cos(GetRotation() - Math.PI * .5f) * 30;
                YAcceleration = (float)Math.Sin(GetRotation() - Math.PI * .5f) * 30;
            }

            else
            {
                XAcceleration = 0;
                YAcceleration = 0;

                if (XVelocity > 0)
                {
                    XVelocity -= 100 * deltaTime;
                }
                else if (XVelocity < 0)
                {
                    XVelocity += 100 * deltaTime;
                }

                if (YVelocity > 0)
                {
                    YVelocity -= 100 * deltaTime;
                }
                else if (YVelocity < 0)
                {
                    YVelocity += 100 * deltaTime;
                }
            }
        }

        private void Rotation(float deltaTime)
        {
            if (Input.IsKeyDown(326)) //6
            {
                Rotate(2f * deltaTime);
            }
            else if (Input.IsKeyDown(324)) //4
            {
                Rotate(-2f * deltaTime);
            }
        }

        private void bounceCheck(float deltaTime)
        {
            //check left and right sides of window
            if (hitbox.Right >= Game.windowsizeX || hitbox.Left <= 0)
            {
                XVelocity = -XVelocity;

            }
            //bounce of left and right of window
            if (hitbox.Bottom >= Game.windowsizeY || hitbox.Top <= 0)
            {

                YVelocity = -YVelocity;

            }
        }
    }
}
