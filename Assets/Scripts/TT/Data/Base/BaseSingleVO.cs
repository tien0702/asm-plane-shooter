using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

namespace TT.Data.Base
{
    public class BaseSingleVO
    {
        protected JSONNode data;
        protected string dataName;
        public virtual string DataName
        {
            set => dataName = value;
            get => dataName;
        }

        public bool IsArray => data.IsArray;
        public int LengthArray => data.IsArray ? data.AsArray.Count : 0;

        public JSONArray Array => data.AsArray;

        protected virtual void LoadData(string nameData)
        {
            LoadDataFromText(ResourceManager.Instance.GetDataText(nameData));
        }

        public virtual bool LoadDataFromText(string content)
        {
            data = JSONNode.Parse(content)["data"];
            return data != null;
        }

        public virtual T GetData<T>(int index)
        {
            if (!IsArray || index < 0 || index >= LengthArray) return default(T);
            return JsonUtility.FromJson<T>(data.AsArray[index].ToString());
        }
    }
}
