using UnityEngine;
using UnityEngine.UI;

public class HealthBarComponent : MonoBehaviour
{
    [SerializeField] private Image _health;
    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void LateUpdate()
    {
        gameObject.transform.LookAt(_mainCamera.transform);
    }

    public void SetHealth(float health)
    {
        _health.fillAmount = health / 100;
    }
}
