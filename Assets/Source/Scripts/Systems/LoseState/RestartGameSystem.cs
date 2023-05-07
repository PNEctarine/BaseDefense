using Kuhpik;

public class RestartGameSystem : GameSystemWithScreen<LoseUI>
{
    public override void OnStateEnter()
    {
        screen.RestartButton.onClick.AddListener(() =>
        {
            game.Player.PlayerReset(game.Level.Spawnpoint);
            Bootstrap.Instance.ChangeGameState(GameStateID.Game);
        });
    }

    public override void OnStateExit()
    {
        screen.RestartButton.onClick.RemoveAllListeners();
    }
}
