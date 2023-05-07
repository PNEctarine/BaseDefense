using System;
using System.Collections.Generic;
using UnityEngine;

namespace Kuhpik
{
    /// <summary>
    /// Used to store game data. Change it the way you want.
    /// </summary>
    [Serializable]
    public class GameData
    {
        public PlayerComponent Player;
        public EnemyComponent Enemy;
        public LevelComponent Level;

        public List<EnemyComponent> Enemies = new List<EnemyComponent>();

        public Vector2 InputVector;

        public int CollectedCash;
        public float Velocity;
        public bool IsShooting;

        // Example (I use public fields for data, but u free to use properties\methods etc)
        // public float LevelProgress;
        // public Enemy[] Enemies;
    }
}