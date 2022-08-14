using UnityEngine;
using UnityEngine.UIElements;

namespace TeaGames.Unity.UIFramework.Runtime
{
    public class ConfirmPopup : Popup
    {
        public event System.Action Confirmed;
        public event System.Action Cancled;

        [Header("Confirm Popup")]
        [SerializeField] private string _confirmButtonClass = "confirm-popup__confirm-button";
        [SerializeField] private string _cancleButtonClass = "confirm-popup__cancle-button";

        protected Button cancleButton;
        protected Button confirmButton;

        public override void Init(UIManager uiManager)
        {
            base.Init(uiManager);

            confirmButton = root.Q<Button>(_confirmButtonClass);
            cancleButton = root.Q<Button>(_cancleButtonClass);

            confirmButton.RegisterCallback<ClickEvent>(e => OnConfirmed());
            cancleButton.RegisterCallback<ClickEvent>(e => OnCancled());
        }

        private void OnConfirmed()
        {
            Confirmed?.Invoke();
            uiManager.ClosePopup(this);
        }

        private void OnCancled()
        {
            Cancled?.Invoke();
            uiManager.ClosePopup(this);
        }
    }
}
