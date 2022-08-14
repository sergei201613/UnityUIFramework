using UnityEngine.UIElements;

namespace TeaGames.Unity.UIFramework.Runtime
{
    public class Panel : Widget
    {
        private const string CloseButtonQuery = "panel__close-button";

        public override void Init(UIManager uiManager)
        {
            base.Init(uiManager);

            var closeBtn = root.Q<Button>(CloseButtonQuery);
            closeBtn?.RegisterCallback<ClickEvent>(e => OnCloseButtonClicked());
        }

        protected virtual void OnCloseButtonClicked()
        {
            uiManager.Back();
        }
    }
}
