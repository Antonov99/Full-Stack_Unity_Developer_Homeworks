using System;
using JetBrains.Annotations;
using Modules.Money;
using Zenject;

namespace Game.UI
{
    [UsedImplicitly]
    public class MoneyPresenter:IInitializable, IDisposable
    {
        private readonly IMoneyView _moneyView;
        private readonly IMoneyStorage _moneyStorage;

        public MoneyPresenter(IMoneyView moneyView, IMoneyStorage moneyStorage)
        {
            _moneyView = moneyView;
            _moneyStorage = moneyStorage;
        }

        public void Initialize()
        {
            _moneyStorage.OnMoneyChanged += _moneyView.UpdateMoney;
            _moneyView.SetMoney(_moneyStorage.Money.ToString());
        }
        
        public void Dispose()
        {
            _moneyStorage.OnMoneyChanged -= _moneyView.UpdateMoney;
        }
    }
}