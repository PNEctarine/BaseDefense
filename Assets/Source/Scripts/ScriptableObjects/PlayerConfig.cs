using UnityEngine;

[CreateAssetMenu(menuName = "Config/PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
    public float MoveSpeed;
    public float RotationSpeed;
    public float FireRate;

    public int Capacity;
}
