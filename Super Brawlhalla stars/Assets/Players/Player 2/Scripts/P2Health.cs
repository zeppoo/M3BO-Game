using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Health : MonoBehaviour
{
    public float dmgCounter;
    public float knockbackPower;
    public float knockbackPowerUp;
    private Rigidbody2D rb;
    public int maxHealth = 100;
    int currentHealth;
    public Transform attacker;
    int attackPosition = 0;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void TakeDamage(float damage)
    {
        Debug.Log("Succesful hit");
        GetAttackerPosition();
        rb.velocity = new Vector2(knockbackPower * attackPosition, knockbackPowerUp) * dmgCounter;
        dmgCounter += damage;
    }

    public void GetAttackerPosition()
    {
        if (attacker.position.x < transform.position.x)
        {
            attackPosition = 1;
        }
        else if (attacker.position.x > transform.position.x)
        {
            attackPosition = -1;
        }
    }

    void Die()
    {
        Debug.Log("K.O");
    }
}
