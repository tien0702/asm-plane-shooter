using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TT.Target.Base;

namespace TT.Target.Common
{
    public class FrontNotBlockedTarget : MonoBehaviour, ICheckTarget
    {
        public Transform model;
        public float visionAngle;
        public float distance;
        public bool CheckTarget(Transform target)
        {
            float realVision = visionAngle / 2f;
            Quaternion rotation1 = Quaternion.Euler(0, 0, realVision);
            Quaternion rotation2 = Quaternion.Euler(0, 0, -realVision);
            Debug.DrawLine(transform.position, transform.position + rotation1 * model.up * distance);
            Debug.DrawLine(transform.position, transform.position + rotation2 * model.up * distance);
            float angle = Vector2.Angle(model.up, target.position - transform.position);
            if (angle > realVision) return false;

            if (CheckObstacle(target)) return false;

            return true;
        }

        protected virtual bool CheckObstacle(Transform target)
        {
            Vector3 direction = target.position - transform.position;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, distance);
            Debug.DrawLine(transform.position, transform.position + direction.normalized * distance);

            if (hit.collider == null) return false;
            if (hit.collider.transform.parent != target) return true;
            return false;
        }
    }
}
