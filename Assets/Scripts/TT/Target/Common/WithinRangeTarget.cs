using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TT.Target.Base;

namespace TT.Target.Common
{
    public class WithinRangeTarget : MonoBehaviour, ICheckTarget
    {
        public float range;
        public bool CheckTarget(Transform target)
        {
            return Vector3.Distance(transform.position, target.position) <= range;
        }
    }
}
