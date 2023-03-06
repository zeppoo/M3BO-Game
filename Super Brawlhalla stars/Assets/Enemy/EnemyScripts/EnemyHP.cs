using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public float dmgCounter;
    public float knockbackPower;
    private Rigidbody2D rb;
    public int maxHealth = 100;
    int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void TakeDamage(float damage)
    {
        
        dmgCounter += damage;

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

    }

    void Die()
    {
        Debug.Log("K.O");
    }
}
