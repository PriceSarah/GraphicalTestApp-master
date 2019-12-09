using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class SansIcon : Entity
    {
        AABB _sHitbox;
        Sprite _sSprite;
        public SansIcon(float x, float y, string _SansSprite) : base(x, y)
        {
            X = x;
            Y = y;

            Sprite sansSprite = new Sprite(_SansSprite);
            AABB sansHitBox = new AABB(sansSprite.Height, sansSprite.Width);

            _sSprite = sansSprite;
            _sHitbox = sansHitBox;

            AddChild(sansSprite);
            AddChild(sansHitBox);
        }
    }
}
