using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TT.Movement.Base;

namespace TT.Movement.Controller
{
    public class TypeMovementController : BaseMovement
    {
        [SerializeField] protected Transform model;
        protected ITypeMovement[] typeMovements;

        protected virtual void Awake()
        {
            typeMovements = GetComponents<ITypeMovement>();
        }

        protected virtual void Update()
        {
            Vector3 direction = Vector3.zero;
            foreach (ITypeMovement type in typeMovements)
            {
                direction += type.GetDirectionMove();
            }
            model.up = direction;
            base.Move(direction);
        }

    }
}
