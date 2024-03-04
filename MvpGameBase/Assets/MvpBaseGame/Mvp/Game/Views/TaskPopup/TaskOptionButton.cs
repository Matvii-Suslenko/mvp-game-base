using UnityEngine.UI;
using UnityEngine;
using System;

namespace MvpBaseGame.Mvp.Game.Views.TaskPopup
{
    public class TaskOptionButton : MonoBehaviour, ITaskOptionButton
    {
        public event Action<int> ButtonClicked;
        
        [SerializeField]
        private Button _button;
        
        [SerializeField]
        private Text _text;

        private int _index;

        protected void Awake()
        {
            _button.onClick.AddListener(OnButtonClicked);
        }

        private void OnButtonClicked()
        {
            ButtonClicked?.Invoke(_index);
        }

        public void SetIndex(int index)
        {
            _index = index;
        }

        public void SetText(string text)
        {
            _text.text = text;
        }

        public void SetInteractable(bool isInteractable)
        {
            _button.interactable = isInteractable;
        }

        protected void OnDestroy()
        {
            _button.onClick.RemoveListener(OnButtonClicked);
        }
    }
}
