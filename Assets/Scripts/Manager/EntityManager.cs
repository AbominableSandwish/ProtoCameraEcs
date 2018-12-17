using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Nastrong
{
    public class EntityManager : MonoBehaviour
    {
        public static EntityManager Instance { get; private set; }

        public void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
        }

        private List<GameObject> entities = new List<GameObject>();

        public List<GameObject> GetEntities()
        {
            List<Entity> e = FindObjectsOfType<Entity>().ToList();
            foreach (var entity in e)
            {
                if (!this.entities.Contains(entity.gameObject))
                    entities.Add(entity.gameObject);
            }

            return entities;
        }
    }
}