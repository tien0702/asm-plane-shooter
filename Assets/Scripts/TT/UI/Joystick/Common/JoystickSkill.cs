using TT.UI.Joystick.Controller;
using UnityEngine.EventSystems;

namespace TT.UI.Joystick.Common
{
    public class JoystickSkill : JoystickController
    {
        protected override void Awake()
        {
            base.Awake();
            joystick.gameObject.SetActive(false);
        }

        public override void OnBeginDrag(PointerEventData eventData)
        {
            base.OnBeginDrag(eventData);
            joystick.gameObject.SetActive(true);
        }

        public override void OnEndDrag(PointerEventData eventData)
        {
            base.OnEndDrag(eventData);
            joystick.gameObject.SetActive(false);
        }
    }
}
