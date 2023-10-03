using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TT.DesignPattern
{
    public class ObjectPooler : MonoBehaviour
    {
        #region Manager ObjectPooler
        protected static Dictionary<string, ObjectPooler> poolers = new Dictionary<string, ObjectPooler>();

        public static void AddPool(ObjectPooler pooler, bool removeOnExists = true)
        {
            if (pooler == null)
            {
                Debug.Log("Pool can't is null");
                return;
            }
            string poolName = pooler.ObjectPoolerID;
            if (poolers.ContainsKey(poolName))
            {
                Debug.Log(string.Format("Pool {0} is exists!", poolName));
                if (removeOnExists)
                {
                    poolers.Remove(poolName);
                }
            }
            else
            {
                poolers.Add(poolName, pooler);
            }
        }

        public static void RemovePool(string poolName)
        {
            if (poolers.ContainsKey(poolName))
            {
                poolers.Remove(poolName);
            }
        }

        public static ObjectPooler GetObjectPooler(string poolName)
        {
            if (poolers.ContainsKey(poolName)) return poolers[poolName];
            return null;
        }

        #endregion

        [SerializeField] protected string objectPoolerID;
        [SerializeField] protected bool canExpand = true;
        [SerializeField] protected int poolSize = 20;
        [SerializeField] protected GameObject objectToPool;
        protected Pool poolHolder;

        public bool CanExpand => canExpand;
        public int PoolSize => poolSize;
        public string ObjectPoolerID => objectPoolerID;
        public Pool PoolHolder => poolHolder;

        protected virtual void Awake()
        {
            poolHolder = CreatePoolHolder();
            this.FillPool();
            ObjectPooler.AddPool(this);
        }

        protected virtual Pool CreatePoolHolder()
        {
            GameObject obj = new GameObject(DeterminePoolName());
            Pool pool = obj.AddComponent<Pool>();
            return pool;
        }

        public virtual string DeterminePoolName()
        {
            return "[Pooler] " + this.name;
        }

        public virtual void FillPool()
        {
            int amount = poolSize - poolHolder.PooledGameObjects.Count;
            for (int i = 0; i < amount; i++)
                AddOneObjectToPool();
        }

        public virtual GameObject GetObject()
        {
            if (poolHolder == null) return null;
            foreach (GameObject obj in poolHolder.PooledGameObjects)
                if (!obj.activeInHierarchy) return obj;

            if (canExpand) return AddOneObjectToPool();

            return null;
        }

        protected virtual GameObject AddOneObjectToPool()
        {
            GameObject newObject = Instantiate(objectToPool, poolHolder.transform);
            newObject.SetActive(false);
            newObject.name = objectToPool.name;
            poolHolder.PooledGameObjects.Add(newObject);

            return newObject;
        }

        protected virtual void DestroyPool()
        {
            foreach (GameObject obj in poolHolder.PooledGameObjects)
            {
                Destroy(obj);
            }
            ObjectPooler.RemovePool(objectPoolerID);
            Destroy(poolHolder.gameObject);
        }
    }
}
