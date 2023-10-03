using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TT.Target.Base;


namespace TT.Target.Common
{
    public class NearestTarget : MonoBehaviour, ICheckBestTarget
    {
        public bool CheckBestTarget(Transform target1, Transform target2)
        {
            if (target1 == null || target2 == null) return false;

            float distance1 = Vector3.Distance(transform.position, target1.position);
            float distance2 = Vector3.Distance(transform.position, target2.position);

            return distance2 < distance1;
        }
    }
}