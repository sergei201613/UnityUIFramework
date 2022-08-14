using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace TeaGames.Unity.UIFramework.Runtime
{
    public class Popup : Panel
    {
        [Header("Popup")]
        [SerializeField] private string _popupClass = "popup";
        [SerializeField] private string _textClass = "popup__text";
        [SerializeField] private string _openedClass = "popup--opened";
        [SerializeField] private string _hiddenClass = "popup--hidden";

        public string Text
        {
            get => label.text;
            set => label.text = value;
        }

        protected VisualElement popup;
        protected Label label;

        public override void Init(UIManager uiManager)
        {
            base.Init(uiManager);

            popup = root.Q(_popupClass);
            label = root.Q<Label>(_textClass);
        }

        public void Show(System.Action onComplete = null)
        {
            popup.RegisterCallback<TransitionEndEvent>(e => onComplete?.Invoke());
            StartCoroutine(ShowCoroutine());
        }

        public void Hide(System.Action onComplete = null)
        {
            popup.RegisterCallback<TransitionEndEvent>(e => onComplete?.Invoke());
            popup.RemoveFromClassList(_openedClass);
            popup.AddToClassList(_hiddenClass);
        }

        protected override void OnCloseButtonClicked()
        {
            uiManager.ClosePopup(this);
        }

        private IEnumerator ShowCoroutine()
        {
            popup.AddToClassList(_hiddenClass);

            yield return new WaitForEndOfFrame();

            popup.RemoveFromClassList(_hiddenClass);
            popup.AddToClassList(_openedClass);
        }
    }
}
