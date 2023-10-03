using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TT.Process.Common;
using TT.Target.Base;

namespace TT.Target.Common
{
    public class LowestHealthTarget : MonoBehaviour, ICheckBestTarget
    {
        public bool CheckBestTarget(Transform target1, Transform target2)
        {
            if (target1 == null || target2 == null) return false;

            HealthController health1 = target1.GetComponent<HealthController>();
            HealthController health2 = target2.GetComponent<HealthController>();

            if (health2 == null) return false;
            if (health1 == null) return true;

            return health2.CurrentValue < health1.CurrentValue;
        }
    }
}
