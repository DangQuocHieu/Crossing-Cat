namespace CrossingCat
{
    using UnityEngine;
    using System.Collections.Generic;

    public abstract class ObjectPool<T> : MonoBehaviour where T : Component
    {
        [SerializeField] private List<T> prefabs;
        [SerializeField] private int initialSize = 10;
        private Dictionary<T, Queue<T>> poolDictionary = new Dictionary<T, Queue<T>>();
        private Dictionary<T, T> instanceToPrefabMap = new Dictionary<T, T>();

        public void InitializePool()
        {
            foreach (T prefab in prefabs)
            {
                if (prefab == null) continue;
                if (!poolDictionary.ContainsKey(prefab))
                {
                    Queue<T> objectPool = new Queue<T>();
                    for (int i = 0; i < initialSize; i++)
                    {
                        objectPool.Enqueue(CreateNewObject(prefab));
                    }
                    poolDictionary.Add(prefab, objectPool);
                }
            }
        }

        private T CreateNewObject(T prefab)
        {
            T newObj = Instantiate(prefab, transform);
            newObj.gameObject.SetActive(false);
            return newObj;
        }

        public T Get(T prefab)
        {
            if (!poolDictionary.TryGetValue(prefab, out Queue<T> targetPool))
            {
                targetPool = new Queue<T>();
                poolDictionary.Add(prefab, targetPool);
            }

            T obj;
            if (targetPool.Count > 0)
            {
                obj = targetPool.Dequeue();
            }
            else
            {
                obj = CreateNewObject(prefab);
            }
            instanceToPrefabMap[obj] = prefab;
            obj.gameObject.SetActive(true);
            obj.transform.SetParent(null);
            return obj;
        }

        public T Get(T prefab, Vector3 position, Quaternion rotation, Transform parent = null)
        {
            T obj = Get(prefab);
            if (obj != null)
            {
                obj.transform.position = position;
                obj.transform.rotation = rotation;
                obj.transform.SetParent(parent);
            }
            return obj;
        }
        public void Return(T obj)
        {
            if (obj == null) return;
            if (instanceToPrefabMap.TryGetValue(obj, out T prefab))
            {
                if (poolDictionary.TryGetValue(prefab, out Queue<T> targetPool))
                {
                    obj.gameObject.SetActive(false);
                    obj.transform.SetParent(transform);
                    targetPool.Enqueue(obj);
                    instanceToPrefabMap.Remove(obj);
                }
                else
                {
                    Destroy(obj.gameObject);
                }
            }
            else
            {
                Destroy(obj.gameObject);
            }
        }
    }
}
