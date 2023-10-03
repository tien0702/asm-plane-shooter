using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TT.Movement.Base
{
    public class BaseMovement : MonoBehaviour
    {
        [SerializeField] protected float speed;

        protected virtual void Move(Vector3 direction)
        {
            transform.position += direction.normalized * Time.deltaTime * speed;
        }
    }
}