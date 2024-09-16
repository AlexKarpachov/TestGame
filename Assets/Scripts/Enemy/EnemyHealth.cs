using TMPro;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int currentHealth;
    [SerializeField] int reward = 20;

    Bank bank;
    Lives livesScript;
    ObjectPool pool;
    int initialHealth = 100;

    private void OnEnable()
    {
        bank = FindAnyObjectByType<Bank>();
        currentHealth = initialHealth;
        pool = FindObjectOfType<ObjectPool>();
        livesScript = FindObjectOfType<Lives>();
    }

    private void Start()
    {
    }

    public void DecreaseHealth(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            bank.MoneyDeposit(reward);
            livesScript.ScoreUpdate();
            pool.ReturnToPool("small enemy", gameObject);
        }
    }
}
