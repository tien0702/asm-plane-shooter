using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TT.DesignPattern;
using TT.Experience.Model;
using TT.Experience.Base;

namespace TT.Experience.Manager
{
    public class ExperienceManager : Singleton<ExperienceManager>
    {
        protected Dictionary<string, ExperienceInfo> experienceInfos = new Dictionary<string, ExperienceInfo>();
        protected ExperienceVO experienceVO;

        public ExperienceManager()
        {
            experienceVO = new ExperienceVO();
            ExperienceInfo[] exps = experienceVO.GetExperienceInfos();
            foreach (var experience in exps)
            {
                experienceInfos.Add(experience.ObjectType, experience);
            }
        }

        public int GetExperienPoint(string objectType, int level)
        {
            if (!experienceInfos.ContainsKey(objectType) || level <= 0) return 0;

            return experienceInfos[objectType].ExperiencePoints[level - 1];
        }
    }
}