using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] float enemySpeed = 10f;

    Lives livesScript;
    ObjectPool pool;
    Transform target;

    int waypointIndex = 0;

    private void OnEnable()
    {
        target = Waypoints.waypoints[0];
        pool = FindObjectOfType<ObjectPool>();
        waypointIndex = 0;
        livesScript = FindObjectOfType<Lives>();
    }

    private void Update()
    {
        MoveTo();
    }
    void MoveTo()
    {
        if (waypointIndex < Waypoints.waypoints.Length)
        {
            transform.position = Vector2.MoveTowards(transform.position, Waypoints.waypoints[waypointIndex].position, enemySpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, Waypoints.waypoints[waypointIndex].position) < 0.1f)
            {
                waypointIndex++;
            }
        }
        else if (waypointIndex >= Waypoints.waypoints.Length)
        {
            livesScript.LivesUpdate();
            pool.ReturnToPool("small enemy", gameObject);
        }
    }
}
