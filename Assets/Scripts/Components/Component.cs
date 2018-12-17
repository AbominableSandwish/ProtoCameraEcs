using UnityEngine;
using System.Collections;

namespace Nastrong
{
    public class Component : MonoBehaviour
    {
        public enum Type : int
        {
            Unknow,
            ComponentMap,
            ComponentMove
        }

        public virtual int type()
        {
            return (int) Type.Unknow;
        }
    }
}
