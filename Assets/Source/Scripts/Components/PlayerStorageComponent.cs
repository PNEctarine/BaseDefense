using UnityEngine;

public class PlayerStorageComponent : MonoBehaviour
{
    [SerializeField] private PlayerConfig _playerConfig;

    private int _cash;
    private int _capacity;

    private void Start()
    {
        _capacity = _playerConfig.Capacity;
    }

    public void CashDepositing()
    {
        GameEvents.CashDepositing_E?.Invoke(_cash);
        _cash = 0;
    }

    public void MoneyLosing()
    {
        _cash = 0;
    }

    public bool CashGrab(int income)
    {
        if (_cash + income <= _capacity)
        {
            _cash += income;
            return true;
        }

        return false;
    }
}
