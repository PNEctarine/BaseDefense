using Kuhpik;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(PlayerStorageComponent))]
public class PlayerComponent : MonoBehaviour
{
    [field: SerializeField] public NavMeshAgent Agent { get; private set; }
    [field: SerializeField] public Animator Animator { get; private set; }

    [SerializeField] private HealthBarComponent _healthBarComponent;
    [SerializeField] private ParticleSystem _shootVFX;
    [SerializeField] private float _startHealth;

    private PlayerStorageComponent _playerStorageComponent;
    private float _health;

    private const string _deathAnimationName = "Death";
    private const string _walkingAnimationName = "Walking";
    private const string _restartAnimationName = "Restart";

    private void Start()
    {
        _health = _startHealth;
        _playerStorageComponent = GetComponent<PlayerStorageComponent>();
    }

    public void PlayerReset(Transform spawnPoint)
    {
        gameObject.transform.position = spawnPoint.position;

        _health = _startHealth;
        _healthBarComponent.SetHealth(_health);

        Animator.SetBool(_deathAnimationName, false);
        Animator.SetBool(_walkingAnimationName, false);
        Animator.SetBool(_restartAnimationName, true);
        Agent.enabled = true;
    }

    public void ShootEffect()
    {
        _shootVFX.Play();
    }

    public void AddHealth()
    {
        _health = _startHealth;
        _healthBarComponent.SetHealth(_health);
    }

    public void TakeDamage()
    {
        _health -= 10;
        _healthBarComponent.SetHealth(_health);

        if (_health <= 0)
        {
            Animator.SetTrigger(_deathAnimationName);
            Animator.SetLayerWeight(1, 0);
            Agent.enabled = false;

            _shootVFX.Stop();
            _playerStorageComponent.MoneyLosing();

            Bootstrap.Instance.ChangeGameState(GameStateID.Lose);
        }
    }
}
