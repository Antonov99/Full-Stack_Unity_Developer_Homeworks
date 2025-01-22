namespace Game.UI
{
    public interface IMoneyView
    {
        public void UpdateMoney(int newValue, int previousValue);
        public void SetMoney(string money);
    }
}