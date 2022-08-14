using UnityEngine;
using UnityEngine.UIElements;

namespace TeaGames.Unity.UIFramework.Runtime
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(UIDocument))]
    public class Widget : MonoBehaviour
    {
        protected VisualElement root;
        protected UIManager uiManager;

        public virtual void Init(UIManager uiManager)
        {
            this.uiManager = uiManager;

            if (TryGetComponent<UIDocument>(out var uiDocument))
            {
                root = uiDocument.rootVisualElement;
            }
            else
            {
                throw new MissingComponentException($"Missing UIDocument on {gameObject.name}!");
            }
        }
    }
}