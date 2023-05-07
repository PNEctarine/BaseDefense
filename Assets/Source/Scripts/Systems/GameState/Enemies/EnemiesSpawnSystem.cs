using System.Collections;
using Kuhpik;
using UnityEngine;

public class EnemiesSpawnSystem : GameSystem
{
    public override void OnInit()
    {
        GameEvents.ResetEnemy_E += EnemyReset;

        for (int i = 0; i < game.Level.Enemies; i++)
        {
            EnemiesSpawn();
        }
    }

    private void EnemiesSpawn()
    {
        EnemyComponent enemy = null;
        bool validPositionFound = false;

        while (!validPositionFound)
        {
            float randomX = Random.Range(game.Level.Battlefield.position.x - game.Level.Battlefield.lossyScale.x / 2f, game.Level.Battlefield.position.x + game.Level.Battlefield.lossyScale.x / 2f);
            float randomZ = Random.Range(game.Level.Battlefield.position.z - game.Level.Battlefield.lossyScale.z / 2f, game.Level.Battlefield.position.z + game.Level.Battlefield.lossyScale.z / 2f);

            if (!Physics.CheckSphere(new Vector3(randomX, 0, randomZ), 1f))
            {
                enemy = Instantiate(game.Enemy, new Vector3(randomX, 0, randomZ), Quaternion.identity);
                validPositionFound = true;
            }
        }

        game.Enemies.Add(enemy);
    }

    private void EnemyReset(EnemyComponent enemyComponent)
    {
        StartCoroutine(RepawmDalay(enemyComponent));
    }

    private IEnumerator RepawmDalay(EnemyComponent enemyComponent)
    {
        yield return new WaitForSeconds(2);

        float randomX = Random.Range(game.Level.Battlefield.position.x - game.Level.Battlefield.lossyScale.x / 2, game.Level.Battlefield.position.x + game.Level.Battlefield.lossyScale.x / 2);
        float randomZ = Random.Range(game.Level.Battlefield.position.z - game.Level.Battlefield.lossyScale.z / 2, game.Level.Battlefield.position.z + game.Level.Battlefield.lossyScale.z / 2);

        enemyComponent.transform.position = new Vector3(randomX, 0, randomZ);
        enemyComponent.gameObject.SetActive(true);
    }
}
