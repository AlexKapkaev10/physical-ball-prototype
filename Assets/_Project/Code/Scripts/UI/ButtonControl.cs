using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Project.Code.Game
{
    public class ButtonControl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private ButtonControlType _type;
        
        public event Action<ButtonControlType, bool> ControlClicked;
        
        public void OnPointerDown(PointerEventData eventData)
        {
            ControlClicked?.Invoke(_type, true);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            ControlClicked?.Invoke(_type, false);
        }
    }
}