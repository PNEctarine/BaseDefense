using Kuhpik;

public class CashSystem : GameSystemWithScreen<GameUI>
{
    public override void OnInit()
    {
        screen.SetCash(player.Cash);
        GameEvents.CashDepositing_E += CashDepositing;
    }

    private void CashDepositing(int income)
    {
        player.Cash += income;
        screen.SetCash(player.Cash);

        Bootstrap.Instance.SaveGame();
    }
}
