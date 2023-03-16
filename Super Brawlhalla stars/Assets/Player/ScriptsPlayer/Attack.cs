using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask Enemies;
    public float attackDamage;
    public float attackCooldown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && attackCooldown == 0)
        {
            attackCooldown = 2;
            attack();
        }
    }

    void attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, Enemies);

        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("Succesful hit");

            enemy.GetComponent<EnemyHP>().TakeDamage(attackDamage);
        }

        while (attackCooldown > 0)
        {
            attackCooldown -= Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

