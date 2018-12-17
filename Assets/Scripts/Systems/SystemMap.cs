using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Nastrong
{
    public class SystemMap : System
    {
        private ComponentMap component;

        public void Start()
        {
            List<GameObject> tmpEntities = GetEntities();
            //Get Entity Contain ComponentMove
            foreach (var e in tmpEntities)
            {
                if (e.GetComponent<ComponentMap>() != null)
                {
                    component = e.GetComponent<ComponentMap>();
                    break;
                }
            }
        }

        private void OnDrawGizmos()
            {
                if (component != null)
                {
                    Gizmos.color = Color.blue;
                    Gizmos.DrawLine(component.OffSet, component.OffSet + component.SizeMap * Vector2.up);
                    Gizmos.DrawLine(component.OffSet, component.OffSet + component.SizeMap * Vector2.right);
                    Gizmos.DrawLine(component.OffSet + component.SizeMap, component.OffSet + component.SizeMap * Vector2.right);
                    Gizmos.DrawLine(component.OffSet + component.SizeMap, component.OffSet + component.SizeMap * Vector2.up);
                }
            }
        }
    }
