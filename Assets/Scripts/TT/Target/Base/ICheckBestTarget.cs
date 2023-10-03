using UnityEngine;

namespace TT.Target.Base
{
    public interface ICheckBestTarget
    {
        public bool CheckBestTarget(Transform target1, Transform target2);
    }
}