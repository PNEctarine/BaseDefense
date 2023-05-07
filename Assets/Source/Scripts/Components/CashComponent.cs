using UnityEngine;

public class CashComponent : MonoBehaviour
{
    [field: SerializeField] public int NominalValue { get; private set; }
    [field: SerializeField] public int ChanceOfDrop { get; private set; }
}
