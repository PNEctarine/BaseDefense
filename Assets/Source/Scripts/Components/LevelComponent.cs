using UnityEngine;

public class LevelComponent : MonoBehaviour
{
    [field: SerializeField] public Transform Base { get; private set; }
    [field: SerializeField] public Transform Battlefield { get; private set; }
    [field: SerializeField] public Transform Spawnpoint { get; private set; }
    [field: SerializeField] public int Enemies { get; private set; }
}
