using Kuhpik;

public class PlayerAnimationSystem : GameSystem
{
    private const string _walkingName = "Walking";
    public override void OnUpdate()
    {
        WalkingAnimationUpdate();
        AimAnimationUpdate();
    }

    private void WalkingAnimationUpdate()
    {
        game.Player.Animator.SetBool(_walkingName, game.Velocity > 0);
    }

    private void AimAnimationUpdate()
    {
        if (game.IsShooting)
        {
            game.Player.Animator.SetLayerWeight(1, 1);
        }

        else
        {
            game.Player.Animator.SetLayerWeight(1, 0);
        }
    }
}
