using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public bool attackStat;
    public LayerMask Enemies;
    public float attackDamage;
    public float attackCooldown = 0.7f;
    public float attackCounter;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && attackStat == true)
        {
            attackStat = false;
            attack();
        }
        
        if (attackStat == false)
        {
            attackCounter += Time.deltaTime;
            if(attackCounter>attackCooldown)
            {
                attackCounter = 0;
                attackStat = true;
            } 
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

    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

