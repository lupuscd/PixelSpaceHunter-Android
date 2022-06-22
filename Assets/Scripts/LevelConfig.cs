using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelConfig : MonoBehaviour
{
    //[SerializeField] GameObject enemyPrefab;
    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] int numberOfEnemies = 5;
    [SerializeField] float moveSpeed = 0.3f;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 2f;

    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }
    public int GetNumberOfEnemies()
    {
        return numberOfEnemies;
    }
    public float GetMoveSpeed()
    {
        return moveSpeed;
    }
    public float GetMinTimeBetweenShots()
    {
        return minTimeBetweenShots;
    }
    public float GetMaxTimeBetweenShots()
    {
        return maxTimeBetweenShots;
    }
}
