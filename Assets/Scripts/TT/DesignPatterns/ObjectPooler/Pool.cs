using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TT.DesignPattern
{
    public class Pool : MonoBehaviour
    {
        public List<GameObject> PooledGameObjects = new List<GameObject>();
    }
}