using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TT.EntityStat.Base;

namespace TT.Item.Base
{
    [System.Serializable]
    public class ItemInfo
    {
        public LinkedList<Bonus> Bonuses;
    }

    public class BaseItem : MonoBehaviour
    {
        public virtual void Use()
        {

        }
    }
}
