using Kuhpik;
using UnityEngine;

public class LoadingSystem : GameSystem
{
    [SerializeField] private PlayerComponent _player;
    [SerializeField] private EnemyComponent _enemy;
    [SerializeField] private LevelComponent _levelComponent;

    public override void OnInit()
    {
        game.Player = _player;
        game.Enemy = _enemy;
        game.Level = _levelComponent;
    }
}
