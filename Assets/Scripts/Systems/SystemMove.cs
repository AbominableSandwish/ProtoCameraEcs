using System.Collections.Generic;
using UnityEngine;

namespace Nastrong
{
    public class SystemMove : System
    {
        private Vector3 cameraPosition;
        private List<ComponentMove> components;
        private ComponentMap map;

        public void Start()
        {
            components = new List<ComponentMove>();
            List<GameObject> tmpEntities = GetEntities();
            //Get Entity Contain ComponentMove
            foreach (var e in tmpEntities) {
                if (e.GetComponent<ComponentMove>() != null)
                {
                    components.Add(e.GetComponent<ComponentMove>());
                    Debug.Log("ComponentMove Get");
                }

                if (e.GetComponent<ComponentMap>() != null)
                {
                    map = e.GetComponent<ComponentMap>();
                    Debug.Log("ComponentMap Get");
                }
            }
            
        }

        public void Update()
        {
            Vector2 sizeDisplay = new Vector2(Display.main.renderingWidth, Display.main.renderingHeight);

            foreach (var component in components)
            {
                Vector2 mousePosition = Input.mousePosition;
                if ((mousePosition.x >= 0 && mousePosition.x <= sizeDisplay.x)
                    && (mousePosition.y >= 0 && mousePosition.y <= sizeDisplay.y))
                {
                    cameraPosition = component.GetComponent<Transform>().position;
                    component.position = mousePosition;

                    component.bottom = false;
                    component.top = false;
                    component.left = false;
                    component.right = false;

                    Vector2 dir = new Vector2();
                    if (cameraPosition.y > map.OffSet.y ) {
                        if (mousePosition.y < sizeDisplay.y / 100 * 15) {
                            component.bottom = true;
                            dir.y = -1;
                        }
                    }

                    if (cameraPosition.y < map.OffSet.y + map.SizeMap.y) {
                        if (mousePosition.y > sizeDisplay.y / 100 * 85)
                        {
                            component.top = true;
                            dir.y = 1;
                        }
                    }

                    if (cameraPosition.x > map.OffSet.x) {
                        if (mousePosition.x < sizeDisplay.x / 100 * 15) {
                            component.left = true;
                            dir.x = -1;
                        }
                    }

                    if (cameraPosition.x < map.OffSet.x + map.SizeMap.x) {
                        if (mousePosition.x > sizeDisplay.x / 100 * 85) {
                            component.right = true;
                            dir.x = 1;
                        }
                    }

                    component.GetComponent<Transform>().position += (Vector3)dir * component.Velocity * Time.deltaTime;
                }
                else {
                    component.bottom = false;
                    component.top = false;
                    component.left = false;
                    component.right = false;
                }

            }
            
        }

        private void OnDrawGizmos()
        {
            if (components != null) {
                foreach (var component in components) {
                    //Bottom
                    Gizmos.color = Color.red;
                    if (component.bottom)
                        Gizmos.color = Color.green;

                    Gizmos.DrawLine(cameraPosition - Vector3.up * 3.874f + Vector3.left * 10.3f,
                        cameraPosition - Vector3.up * 3.874f - Vector3.left * 10.3f);
                    Gizmos.DrawLine(cameraPosition - Vector3.up * 4.774f + Vector3.left * 10.3f,
                        cameraPosition - Vector3.up * 4.774f - Vector3.left * 10.3f);

                    //Top
                    Gizmos.color = Color.red;
                    if (component.top)
                        Gizmos.color = Color.green;

                    Gizmos.DrawLine(cameraPosition + Vector3.up * 5.87f + Vector3.left * 10.3f,
                        cameraPosition + Vector3.up * 5.87f - Vector3.left * 10.3f);
                    Gizmos.DrawLine(cameraPosition + Vector3.up * 6.77f + Vector3.left * 10.3f,
                        cameraPosition + Vector3.up * 6.77f - Vector3.left * 10.3f);

                    //Left
                    Gizmos.color = Color.red;
                    if (component.right)
                        Gizmos.color = Color.green;

                    Gizmos.DrawLine(cameraPosition + Vector3.up * 6.77f + Vector3.right * 10.3f,
                        cameraPosition - Vector3.up * 4.774f + Vector3.right * 10.3f);
                    Gizmos.DrawLine(cameraPosition + Vector3.up * 6.77f + Vector3.right * 9.3f,
                        cameraPosition - Vector3.up * 4.774f + Vector3.right * 9.3f);

                    //Right
                    Gizmos.color = Color.red;
                    if (component.left)
                        Gizmos.color = Color.green;

                    Gizmos.DrawLine(cameraPosition + Vector3.up * 6.77f + Vector3.left * 10.3f,
                        cameraPosition - Vector3.up * 4.774f + Vector3.left * 10.3f);
                    Gizmos.DrawLine(cameraPosition + Vector3.up * 6.77f + Vector3.left * 9.3f,
                        cameraPosition - Vector3.up * 4.774f + Vector3.left * 9.3f);
                }
            }
        }
    }
}
