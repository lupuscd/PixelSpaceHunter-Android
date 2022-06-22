using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    //configuration
    Paths path;
    LevelConfig levelConfig;
    List<Transform> waypoints;    
    int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = path.GetWaypoints();
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void SetWaveConfig(Paths path, LevelConfig levelConfig) //waveConfig is not the same as the others
    {
        this.path = path;
        this.levelConfig = levelConfig;
    }

    private void Move()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointIndex].transform.position;
            var movementThisFrame = levelConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
    }
}
