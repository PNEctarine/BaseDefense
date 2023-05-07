using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

public class BarrierComponent : MonoBehaviour
{
    [SerializeField] private NavMeshObstacle[] _barriers;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerComponent player))
        {
            gameObject.transform.DOMoveY(-0.9f, 0.5f);
            BarriersEnable(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerComponent player))
        {
            gameObject.transform.DOMoveY(0f, 0.5f);
            BarriersEnable(true);
        }
    }

    private void BarriersEnable(bool enable)
    {
        for (int i = 0; i < _barriers.Length; i++)
        {
            _barriers[i].enabled = enable;
        }
    }
}
