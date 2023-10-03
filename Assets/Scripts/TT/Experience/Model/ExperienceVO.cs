using System;
using System.Collections;
using System.Collections.Generic;
using TT.Data.Base;
using TT.Experience.Base;

namespace TT.Experience.Model
{
    public class ExperienceVO : BaseSingleVO
    {
        public ExperienceVO()
        {
            base.LoadData("ObjectExperience");
        }

        public ExperienceInfo GetExperienceInfo(int index)
        {
            return base.GetData<ExperienceInfo>(index);
        }

        public ExperienceInfo[] GetExperienceInfos()
        {
            ExperienceInfo[] experienceInfos = new ExperienceInfo[Array.Count];
            int count = Array.Count;
            for (int i = 0; i < count; ++i)
            {
                experienceInfos[i] = this.GetData<ExperienceInfo>(i);
            }
            return experienceInfos;
        }
    }
}