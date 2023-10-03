using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TT.Target.Base;

namespace TT.Target.Common
{
    public class WithoutLayerMaskTarget : MonoBehaviour, ICheckTarget
    {
        public LayerMask Masks;
        public bool CheckTarget(Transform target)
        {
            if (target == null) return false;

            return ((Masks.value & (1 << target.gameObject.layer)) == 0);
        }
    }
}