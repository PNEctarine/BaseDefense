using Kuhpik;
using UnityEngine;

[RequireComponent(typeof(PlayerStorageComponent), typeof(PlayerComponent))]
public class PlayerTriggerListenerComponent : MonoBehaviour
{
    private PlayerStorageComponent _playerStorageComponent;
    private PlayerComponent _playerComponent;

    private void Start()
    {
        _playerStorageComponent = GetComponent<PlayerStorageComponent>();
        _playerComponent = GetComponent<PlayerComponent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CashComponent cashComponent))
        {
            bool isGrab = _playerStorageComponent.CashGrab(cashComponent.NominalValue);
            cashComponent.gameObject.SetActive(!isGrab);
        }

        if (other.TryGetComponent(out BattlefieldComponent _))
        {
            Bootstrap.Instance.GameData.IsShooting = true;
        }

        else if (other.TryGetComponent(out BaseComponent _))
        {
            Bootstrap.Instance.GameData.IsShooting = false;

            _playerComponent.AddHealth();
            _playerStorageComponent.CashDepositing();
        }
    }
}
