using Kuhpik;
using UnityEngine;

public class PlayerMovementSystem : GameSystem
{
    [SerializeField] private PlayerConfig _playerConfig;

    private float _playerMovementSpeed;
    private float _playerRotationSpeed;

    public override void OnInit()
    {
        _playerMovementSpeed = _playerConfig.MoveSpeed;
        _playerRotationSpeed = _playerConfig.RotationSpeed;
    }

    public override void OnUpdate()
    {
        Rotate();

        if (game.IsShooting)
        {
            AimMove();
            return;
        }

        Move();
    }

    private void Rotate()
    {
        if (game.InputVector != Vector2.zero)
        {
            var direction = new Vector3(game.InputVector.x, 0, game.InputVector.y).normalized;

            var toRotation = Quaternion.LookRotation(direction, Vector3.up);

            var rotationEulerAngles = toRotation.eulerAngles;
            rotationEulerAngles.y += Camera.main.transform.eulerAngles.y;
            toRotation.eulerAngles = rotationEulerAngles;

            var currentDeltaRotation = Quaternion.RotateTowards(game.Player.transform.rotation,
                toRotation, _playerRotationSpeed * Time.deltaTime);


            game.Player.transform.rotation = currentDeltaRotation;
        }
    }

    private void Move()
    {
        if (game.InputVector != Vector2.zero)
        {
            game.Player.Agent.Move(game.Player.transform.forward * (_playerMovementSpeed * Time.deltaTime));
            game.Velocity = _playerMovementSpeed;
        }

        else
        {
            game.Velocity = 0;
        }
    }

    private void AimMove()
    {
        if (game.InputVector != Vector2.zero)
        {
            var direction = new Vector3(game.InputVector.x, 0, game.InputVector.y).normalized;
            game.Player.Agent.Move(direction * (_playerMovementSpeed * Time.deltaTime));
            game.Velocity = _playerMovementSpeed;
        }

        else
        {
            game.Velocity = 0;
        }
    }
}
