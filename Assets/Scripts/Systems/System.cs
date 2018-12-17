using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEditor;

namespace Nastrong
{
    public class System : MonoBehaviour
    {
        protected List<GameObject> GetEntities()
        {
            return EntityManager.Instance.GetEntities();
        }
    }
}