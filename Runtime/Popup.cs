using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace TeaGames.Unity.UIFramework.Runtime
{
    public class Popup : Panel
    {
        public string Text
        {
            get => label.text;
            set => label.text = value;
        }

        protected VisualElement popup;
        protected Label label;

        [Header("Popup")]
        [SerializeField] private string _popupClass = "popup";
        [SerializeField] private string _labelClass = "popup__label";
        [SerializeField] private string _openedClass = "popup--opened";
        [SerializeField] private string _hiddenClass = "popup--hidden";

        public override void Init(UIManager uiManager)
        {
            base.Init(uiManager);

            popup = root.Q(_popupClass);
            label = root.Q<Label>(_labelClass);
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

        private IEnumerator ShowCoroutine()
        {
            popup.AddToClassList(_hiddenClass);

            yield return new WaitForEndOfFrame();

            popup.RemoveFromClassList(_hiddenClass);
            popup.AddToClassList(_openedClass);
        }
    }
}
