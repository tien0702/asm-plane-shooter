using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TT.Movement.Base;

namespace TT.Movement.Common
{
    public class ZigZagMovement : MonoBehaviour, ITypeMovement
    {
        [SerializeField] protected float maxiumAmplitude;
        [SerializeField] protected Vector3 direction = Vector3.zero;
        protected int rightSide = 1;

        public Vector3 GetDirectionMove()
        {
            if (direction.magnitude > maxiumAmplitude)
            {
                rightSide = -rightSide;
            }

            direction += transform.right * rightSide;
            return direction;
        }
    }
}
