using UnityEngine;

public class CashSpawnComponent : MonoBehaviour
{
    [SerializeField] private CashComponent _cashComponent;

    public void ChanceOfDrop()
    {
        int chance = Random.Range(1, 101);

        if (_cashComponent.ChanceOfDrop >= chance)
        {
            GameObject cash = Instantiate(_cashComponent.gameObject);
            cash.transform.position = gameObject.transform.position;
        }
    }
}
