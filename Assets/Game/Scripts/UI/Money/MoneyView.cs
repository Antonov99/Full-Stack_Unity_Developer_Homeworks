using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Game.UI
{
    public class MoneyView:MonoBehaviour, IMoneyView
    {
        [SerializeField]
        private TMP_Text _money;

        public void UpdateMoney(int newValue, int previousValue)
        {
            {
                DOTween.To(() => previousValue, x => 
                    {
                        previousValue = x; 
                        _money.text = Mathf.FloorToInt(previousValue).ToString();
                    }, newValue, 1f) 
                    .SetEase(Ease.OutBounce); 
            }
        }
        
        public void SetMoney(string money)
        {
            _money.text = money;
        }
    }
}