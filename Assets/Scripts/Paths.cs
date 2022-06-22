using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paths : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;

    public List<Transform> GetWaypoints()
    {
        var pathWaypoints = new List<Transform>();
        foreach (Transform child in gameObject.transform)
        {
            pathWaypoints.Add(child);
        }
        return pathWaypoints;
    }

    public GameObject GetEnemyPrefab()
    {
        return enemyPrefab;
    }
}
