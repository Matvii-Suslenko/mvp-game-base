using MvpBaseGame.Mvp.ViewManagement.Core.Impl;
using MvpBaseGame.Mvp.Game.Data;
using UnityEngine.UI;
using UnityEngine;
using System;

namespace MvpBaseGame.Mvp.Game.Views.TaskPopup
{
    public class TaskPopupView : ScreenBaseView, ITaskPopupView
    {
        public event Action<int> OptionClicked;
        
        [SerializeField]
        private Text _questionText;
        
        [SerializeField]
        private Transform _optionsContainer;
        
        [SerializeField]
        private TaskOptionButton _optionSample;

        private ITaskOptionButton[] _options;

        public void SetGameTask(IGameTask gameTask)
        {
            _questionText.text = gameTask.Question;
            var optionCount = gameTask.Options.Length;
            _options = new ITaskOptionButton[optionCount];

            for (var i = 0; i < optionCount; i++)
            {
                var optionButton = PrefabInstantiator.Instantiate(_optionSample, _optionsContainer);
                var option = gameTask.Options[i];
                
                optionButton.SetText(option);
                optionButton.SetIndex(i);
                optionButton.ButtonClicked += OnOptionClicked;
                optionButton.gameObject.SetActive(true);
                
                _options[i] = optionButton;
            }
        }

        private void OnOptionClicked(int optionNumber)
        {
            OptionClicked?.Invoke(optionNumber);
        }

        protected override void OnInteractableChanged(bool isInteractable)
        {
            base.OnInteractableChanged(isInteractable);
            
            foreach (var option in _options)
            {
                option.SetInteractable(isInteractable);
            }
        }
        
        protected override void OnDestroy()
        {
            foreach (var option in _options)
            {
                option.ButtonClicked -= OnOptionClicked;
            }
            base.OnDestroy();
        }
    }
}
