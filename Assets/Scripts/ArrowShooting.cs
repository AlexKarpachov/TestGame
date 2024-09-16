using UnityEngine;

public class ArrowShooting : MonoBehaviour
{
    [SerializeField] float arrowSpeed = 10f;
    [SerializeField] int damageToSpearman = 40;
    
    Transform target;

    int damage;

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        MoveToEnemy();
    }

    public void SeekEnemy(Transform _target, int _damage)
    {
        target = _target;
        damage = _damage;
    }

    void MoveToEnemy()
    {
        Vector3 direction = target.position - transform.position;
        float distancePerFrame = arrowSpeed * Time.deltaTime;
        EnemyHealth enemyHealth = target.GetComponent<EnemyHealth>();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle +90));

        transform.Translate(direction.normalized * distancePerFrame, Space.World);

        if (direction.magnitude <= distancePerFrame)
        {
            enemyHealth.DecreaseHealth(damage);
            Destroy(gameObject );
        }
    }
}
