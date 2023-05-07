using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static Action<EnemyComponent> ResetEnemy_E;
    public static Action<int> CashDepositing_E;

    public static void ClearEvents()
    {
        ResetEnemy_E = null;
    }
}
