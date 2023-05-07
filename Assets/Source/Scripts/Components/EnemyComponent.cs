using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(CashSpawnComponent))]
public class EnemyComponent : MonoBehaviour
{
    [field: SerializeField] public NavMeshAgent Agent { get; private set; }
    [field: SerializeField] public Animator Animator { get; private set; }

    [SerializeField] private ParticleSystem _bloodVFX;

    [SerializeField] private float _startHealth;
    public float Health { get; private set; }

    private CashSpawnComponent _cashSpawnComponent;
    private bool _isAttack;
    private bool _isAlive;

    private const string _deathAnimationName = "Death";
    private const string _walkingAnimationName = "Walking";

    private void Start()
    {
        _cashSpawnComponent = GetComponent<CashSpawnComponent>();
    }

    private void OnEnable()
    {
        Agent.enabled = true;
        Agent.isStopped = true;
        _isAlive = true;
        _bloodVFX.Stop();

        Health = _startHealth;

        Animator.SetBool("Death", false);
        Animator.SetLayerWeight(1, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerComponent playerComponent) && _isAttack)
        {
            AttackAnimate(true);
            StartCoroutine(HittingPlayer(playerComponent));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerComponent playerComponent) && _isAlive)
        {
            StopAllCoroutines();
            AttackAnimate(false);
        }
    }

    private void AttackAnimate(bool isAttack)
    {
        Animator.SetLayerWeight(1, Convert.ToInt32(isAttack));
    }

    public void AttackPlayer(Transform playerTransform, bool isAttack)
    {
        if (Health > 0 && _isAlive)
        {
            _isAttack = isAttack;
            Agent.isStopped = !isAttack;

            if (isAttack)
            {
                Agent.destination = playerTransform.position;
                Animator.SetBool(_walkingAnimationName, true);
            }

            else
            {
                Animator.SetBool(_walkingAnimationName, false);
                AttackAnimate(false);
            }
        }
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        _bloodVFX.Play();

        if (Health <= 0 && _isAlive)
        {
            _cashSpawnComponent.ChanceOfDrop();
            _isAlive = false;
            _isAttack = false;

            Animator.SetBool(_deathAnimationName, true);
            Animator.SetLayerWeight(1, 0);
            Agent.enabled = false;

            StopAllCoroutines();
            StartCoroutine(HideСorpse());
        }
    }

    private IEnumerator HideСorpse()
    {
        yield return new WaitForSeconds(2);

        GameEvents.ResetEnemy_E?.Invoke(this);
        gameObject.SetActive(false);
    }

    private IEnumerator HittingPlayer(PlayerComponent playerComponent)
    {
        while (_isAttack)
        {
            yield return new WaitForSeconds(1f);
            playerComponent.TakeDamage();
        }
    }
}
