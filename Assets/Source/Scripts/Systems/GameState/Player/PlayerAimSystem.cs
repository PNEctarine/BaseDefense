using System.Collections;
using Kuhpik;
using UnityEngine;

public class PlayerAimSystem : GameSystem
{
    [SerializeField] private PlayerConfig _playerConfig;

    private EnemyComponent _targetEnemy;
    private float _fireRate;
    private bool _hasTarget;

    public override void OnInit()
    {
        _fireRate = _playerConfig.FireRate;
    }

    public override void OnStateExit()
    {
        _hasTarget = false;
    }

    public override void OnUpdate()
    {
        if (game.IsShooting)
        {
            _targetEnemy = FindTarget();

            if (_hasTarget == false)
            {
                _hasTarget = true;
                StopAllCoroutines();
                Shoot();
            }

            _hasTarget = _targetEnemy.Health > 0;
            game.Player.Agent.transform.LookAt(_targetEnemy.transform.position);
        }
    }

    private EnemyComponent FindTarget()
    {
        EnemyComponent targetEnemy = game.Enemies[0];
        float distance = Vector3.Distance(game.Player.transform.position, targetEnemy.transform.position);

        for (int i = 1; i < game.Enemies.Count; i++)
        {
            if (distance > Vector3.Distance(game.Player.transform.position, game.Enemies[i].transform.position) && game.Enemies[i].Health > 0)
            {
                targetEnemy = game.Enemies[i];
                distance = Vector3.Distance(game.Player.transform.position, targetEnemy.transform.position);
            }
        }

        return targetEnemy;
    }

    private void Shoot()
    {
        StartCoroutine(FireRate());
    }

    private IEnumerator FireRate()
    {
        while (game.IsShooting)
        {
            yield return new WaitForSeconds(_fireRate);
            _targetEnemy.TakeDamage(30);
            game.Player.ShootEffect();
        }

        _hasTarget = false;
    }
}
