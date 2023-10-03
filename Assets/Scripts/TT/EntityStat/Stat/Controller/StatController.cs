using System.Collections;
using System.Collections.Generic;
using TT.Entity.Controller;
using TT.Entity.Model;
using UnityEngine;

namespace TT.EntityStat.Base
{
    public class StatController : MonoBehaviour
    {
        protected Dictionary<string, Stat> stats = new Dictionary<string, Stat>();

        EntityController owner;

        protected virtual void Awake()
        {
            owner = GetComponentInParent<EntityController>();
        }

        public virtual void SetStatInfos(StatInfo[] statInfos)
        {
            for (int i = 0; i < statInfos.Length; i++)
            {
                SetStatInfo(statInfos[i]);
            }
        }

        public virtual void SetStatInfo(StatInfo info)
        {
            if (!stats.ContainsKey(info.StatID))
            {
                stats.Add(info.StatID, new Stat());
            }

            stats[info.StatID].Info = info;
        }

        public virtual Stat GetStatByID(string statID)
        {
            if (!stats.ContainsKey(statID)) return null;
            return stats[statID];
        }

        public virtual void AddBonus(Bonus bonus)
        {
            if (!stats.ContainsKey(bonus.Info.StatIDBonus)) return;
            stats[bonus.Info.StatIDBonus].AddBonus(bonus);
        }

        protected virtual void Update()
        {
            foreach (KeyValuePair<string, Stat> kvp in stats)
            {
                kvp.Value.Update(Time.deltaTime);
            }
        }
    }
}
