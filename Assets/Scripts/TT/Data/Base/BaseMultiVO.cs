using System.Collections;
using System.Collections.Generic;

namespace TT.Data.Base
{
    public struct DataTextInfo
    {
        public string Name;
        public string Content;

        public DataTextInfo(string name, string content)
        {
            this.Name = name;
            this.Content = content;
        }
    }

    public class BaseMultiVO
    {
        string type;
        public string Type => type;

        protected Dictionary<string, BaseSingleVO> dic = new Dictionary<string, BaseSingleVO>();

        protected virtual bool LoadData<T>(string typeName) where T : BaseSingleVO, new()
        {
            this.type = typeName;
            DataTextInfo[] texts = ResourceManager.Instance.GetDataTexts(typeName);
            if (texts.Length == 0) return false;

            foreach (DataTextInfo text in texts)
            {
                T single = new T();
                single.DataName = text.Name;
                if (single.LoadDataFromText(text.Content))
                    dic.Add(text.Name, single);
            }
            return true;
        }

        public virtual BaseSingleVO GetBaseSingleVO(string name)
        {
            if (!dic.ContainsKey(name)) return null;
            return dic[name];
        }

        protected virtual T GetData<T>(string name, int index)
        {
            return GetBaseSingleVO(name).GetData<T>(index);
        }
    }
}