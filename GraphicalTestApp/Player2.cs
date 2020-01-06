using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace GraphicalTestApp
{
    class Player2 : Entity
    {
        private Sprite _playerSprite = new Sprite("images/blueBody.png");

        public AABB hitbox;
        
        private Stopwatch stopwatch = new Stopwatch();

        private Turret2 _turret2 = new Turret2(0, 0);

        private int _maxSpeed = 35;

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
            AddChild(_turret2);

            //Updating everything
            OnUpdate += Movement;
            OnUpdate += Rotation;
            OnUpdate += bounceCheck;
            OnUpdate += Fire;
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

            if (Input.IsKeyDown(325))
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
                    XVelocity -= 60 * deltaTime;
                }
                else if (XVelocity < 0)
                {
                    XVelocity += 60 * deltaTime;
                }

                if (YVelocity > 0)
                {
                    YVelocity -= 60 * deltaTime;
                }
                else if (YVelocity < 0)
                {
                    YVelocity += 60 * deltaTime;
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

        private void speedCheck(float deltatime)
        {
            //check movement right
            if (XVelocity > _maxSpeed)
            {
                XVelocity = _maxSpeed;
            }
            //check movment left
            if (XVelocity < -_maxSpeed)
            {
                XVelocity = -_maxSpeed;
            }
            //check movment down
            if (YVelocity > _maxSpeed)
            {
                YVelocity = _maxSpeed;
            }
            //check movment up
            if (YVelocity < -_maxSpeed)
            {
                YVelocity = -_maxSpeed;
            }
        }
        private void Fire(float deltaTime)
        {
            //Fires if Enter is pressed
            if (Input.IsKeyDown(335))
            {
                if (stopwatch.ElapsedMilliseconds > 300)
                {
                    _turret2.Fire();
                }
            }

        }
    }
}
