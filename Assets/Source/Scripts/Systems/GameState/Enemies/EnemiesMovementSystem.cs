using Kuhpik;

public class EnemiesMovementSystem : GameSystem
{
    public override void OnUpdate()
    {
        if (game.IsShooting)
        {
            AttackSet(true);
        }

        else
        {
            AttackSet(false);
        }
    }

    public override void OnStateExit()
    {
        game.IsShooting = false;
        AttackSet(false);
    }

    private void AttackSet(bool isAttack)
    {
        for (int i = 0; i < game.Enemies.Count; i++)
        {
            game.Enemies[i].AttackPlayer(game.Player.transform, isAttack);
        }
    }
}
