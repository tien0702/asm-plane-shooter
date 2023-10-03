using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TT.Entity.Base;
using TT.Entity.Model;
using TT.EntityStat.Base;

namespace TT.Entity.Controller
{
    public abstract class EntityController : MonoBehaviour
    {
        #region Entity Manager

        static Dictionary<string, EntityTypeVO> types = new Dictionary<string, EntityTypeVO>();

        public static EntityTypeVO GetEntityTypeVO(string type)
        {
            if (!types.ContainsKey(type))
            {
                types.Add(type, new EntityTypeVO(type));
            }
            return types[type];
        }

        #endregion

        [SerializeField] protected string type = "";
        [SerializeField] protected EntityInfo info;
        protected EntityTypeVO entityTypeVO;

        public EntityTypeVO TypeVO => entityTypeVO;
        [SerializeField] protected StatController statCtrl;
        public StatController StatCtrl => statCtrl;

        public string Type => type;
        public string EntityName => info.Name;
        public virtual int Level
        {
            get => info.Level;
            set
            {
                info.Level = value;
                OnLevelUp(Level);
            }
        }

        protected virtual void Awake()
        {
            entityTypeVO = EntityController.GetEntityTypeVO(type);
            Level = info.Level;
            gameObject.name = info.Name;
            entityTypeVO.GetStatInfos(info.Name, info.Level);
        }

        protected abstract void OnLevelUp(int level);

        public virtual StatInfo[] GetStatsByLevel(int level)
        {
            return entityTypeVO.GetStatInfos(info.Name, level);
        }
    }
}
