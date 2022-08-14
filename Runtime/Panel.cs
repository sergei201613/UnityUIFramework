using UnityEngine;
using UnityEngine.UIElements;

namespace TeaGames.Unity.UIFramework.Runtime
{
    public class Panel : Widget
    {
        [Header("Panel")]
        [SerializeField] private string _closeButtonClass = "panel__close-button";

        public override void Init(UIManager uiManager)
        {
            base.Init(uiManager);

            var closeBtn = root.Q<Button>(_closeButtonClass);
            closeBtn?.RegisterCallback<ClickEvent>(e => OnCloseButtonClicked());
        }

        protected virtual void OnCloseButtonClicked()
        {
            uiManager.Back();
        }
    }
}
