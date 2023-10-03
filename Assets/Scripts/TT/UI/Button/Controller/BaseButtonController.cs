using System;
using System.Collections.Generic;

namespace TT.UI.Button.Controller
{
    public class BaseButtonController : UnityEngine.UI.Button
    {
        public HashSet<Action<BaseButtonController>> CallbackOnClick = new HashSet<Action<BaseButtonController>>();
        protected override void Awake()
        {
            base.Awake();
            base.onClick.AddListener(OnClick);
        }

        protected virtual void OnClick()
        {
            if (CallbackOnClick != null && CallbackOnClick.Count > 0)
            {
                foreach (Action<BaseButtonController> action in CallbackOnClick)
                    action(this);
            }
        }
    }
}
