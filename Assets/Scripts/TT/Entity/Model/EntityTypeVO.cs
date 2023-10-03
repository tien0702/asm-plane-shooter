using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TT.Data.Base;
using TT.Entity.Base;
using TT.EntityStat.Base;

namespace TT.Entity.Model
{
    public class EntityTypeVO : BaseMultiVO
    {
        public EntityTypeVO(string type) 
        {
            this.LoadData<EntityVO>(type);
        }

        public StatInfo[] GetStatInfos(string name, int level)
        {
            if (!dic.ContainsKey(name))
            {
                Debug.Log(string.Format("Entity name: {0} doesn't exists!", name));
                return null;
            }

            return (dic[name] as EntityVO).GetStatInfos(level);
        }
    }
}
