using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<Paths> path;
    [SerializeField] bool looping = false;
    [SerializeField] LevelConfig levelConfig;

    int startingPath = 0;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping);
    }

    private IEnumerator SpawnAllWaves()
    {
        for (int pathIndex = startingPath; pathIndex < path.Count; pathIndex++)
        {
            var currentPath = path[pathIndex];
            yield return StartCoroutine(SpawnAllEnemiesInWave(levelConfig, currentPath));
        }
    }

    private IEnumerator SpawnAllEnemiesInWave(LevelConfig levelConfig, Paths path)
    {
        for (int enemyCount = 0; enemyCount < levelConfig.GetNumberOfEnemies(); enemyCount++)
        {
            var newEnemy = Instantiate(path.GetEnemyPrefab(), path.GetWaypoints()[0].transform.position,
                Quaternion.identity);
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(path, levelConfig);
            yield return new WaitForSeconds(levelConfig.GetTimeBetweenSpawns());
        }
    }
}
