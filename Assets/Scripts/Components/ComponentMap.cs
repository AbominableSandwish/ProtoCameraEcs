using UnityEngine;
using System.Collections;

namespace Nastrong
{
    public class ComponentMap : Component
    {
        public Vector2 SizeMap;
        public Vector2 OffSet;

        public override int type()
        {
            return (int) Type.ComponentMap;
        }
    }


}
