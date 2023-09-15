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
        int attackPosition = gameObject.GetComponent<Getattackerposition>().GetAttackerPosition();
        rb.velocity = new Vector2(knockbackPower * attackPosition, knockbackPowerUp) * dmgCounter;
        dmgCounter += damage;
    }
}