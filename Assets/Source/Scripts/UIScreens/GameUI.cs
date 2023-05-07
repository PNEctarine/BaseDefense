using Kuhpik;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : UIScreen
{
    [SerializeField] private TextMeshProUGUI _cashTMP;
    [SerializeField] private Button _restartButton;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(() => Bootstrap.Instance.ChangeGameState(GameStateID.Lose));
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveAllListeners();
    }

    public void SetCash(int count)
    {
        _cashTMP.text = CurrencyFormat.Format(count);
    }
}
