using System;
using Modules.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.UI
{
    public class PlanetView : MonoBehaviour
    {
        public event Action OnClick
        {
            add => _button.OnClick += value;
            remove => _button.OnClick -= value;
        }

        public event Action OnHold
        {
            add => _button.OnHold += value;
            remove => _button.OnHold -= value;
        }

        [SerializeField]
        private GameObject _lock;

        [SerializeField]
        private GameObject _coin;

        [SerializeField]
        private Image _icon;

        [SerializeField]
        private GameObject _timeObject;

        [SerializeField]
        private Image _progressBar;
        
        [SerializeField]
        private GameObject _priceObject;
        
        [SerializeField]
        private TMP_Text _timeText;

        [SerializeField]
        private SmartButton _button;

        [SerializeField]
        private TMP_Text _price;
        
        private ParticleAnimator _particleAnimator;
        private Transform _moneyTransform;

        [Inject]
        public void Construct(ParticleAnimator particleAnimator, Transform moneyTransform)
        {
            _particleAnimator = particleAnimator;
            _moneyTransform = moneyTransform;
        }

        public void Unlock(bool value)
        {
            _lock.SetActive(!value);
            _timeObject.SetActive(value);
            _priceObject.SetActive(!value);
        }

        public void SetIcon(Sprite sprite)
        {
            _icon.sprite = sprite;
        }

        public void ShowCoin(bool value)
        {
            _coin.SetActive(value);
        }

        public void CollectCoin()
        {
            _particleAnimator.Emit(_coin.transform.position, _moneyTransform.position);
        }

        public void ShowProgressBar(bool value)
        {
            _timeObject.SetActive(value);
        }

        public void UpdateTime(string text)
        {
            _timeText.text = text;
        }

        public void UpdateProgressBar(float value)
        {
            value = Mathf.Clamp01(value);
            _progressBar.fillAmount = value;
        }

        public void UpdatePrice(string text)
        {
            _price.text = text;
        }
    }
}