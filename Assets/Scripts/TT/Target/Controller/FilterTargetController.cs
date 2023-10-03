using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TT.Target.Base;

namespace TT.Target.Controller
{
    public class FilterTargetController : MonoBehaviour
    {
        ICheckTarget[] checkTargets;
        ICheckBestTarget[] checkBestTargets;

        private void Awake()
        {
            checkTargets = GetComponents<ICheckTarget>();
            checkBestTargets = GetComponents<ICheckBestTarget>();
        }

        public virtual bool CheckTarget(Transform target)
        {
            if (checkTargets == null || checkTargets.Length == 0) return false;
            for (int i = 0; i < checkTargets.Length; ++i)
            {
                if (!checkTargets[i].CheckTarget(target)) return false;
            }
            return true;
        }

        public bool CheckBestTarget(Transform target1, Transform target2)
        {
            if (checkBestTargets == null || checkBestTargets.Length == 0) return true;
            foreach (ICheckBestTarget bestTarget in checkBestTargets)
            {
                if (!bestTarget.CheckBestTarget(target1, target2)) return false;
            }
            return true;
        }
    }


}