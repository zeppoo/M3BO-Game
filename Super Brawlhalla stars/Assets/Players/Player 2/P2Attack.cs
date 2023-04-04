using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Attack : MonoBehaviour
{
    public GameObject hand;

    public Transform upAttack;
    public Transform frontAttack;
    public Transform downAttack;
    public Transform attackPoint;

    public float attackRange = 0.5f;
    public bool attackStat;
    public float attackDamage;
    public float attackCooldown = 0.3f;
    public float attackCounter;

    public LayerMask DamageCollisions;

    // Start is called before the first frame update
    void Start()
    {
        hand = GameObject.Find("P2 Hand");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            attackPoint = downAttack;
            

        } else if (Input.GetKey(KeyCode.UpArrow))
        {
            attackPoint = upAttack;

        } else {attackPoint = frontAttack;}

        hand.transform.position = attackPoint.position; //draws hand at current attack position

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
        
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, DamageCollisions);
        Debug.Log(hitEnemies);
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("Succesful hit");
            if (attackPoint == upAttack)
            {
                enemy.GetComponent<P1Health>().knockbackPowerUp = 10;
                enemy.GetComponent<P1Health>().knockbackPower = 1;
            } else if (attackPoint == downAttack)
            {
                enemy.GetComponent<P1Health>().knockbackPowerUp = -2;
                enemy.GetComponent<P1Health>().knockbackPower = 2;
            } else if (attackPoint == frontAttack)
            {
                enemy.GetComponent<P1Health>().knockbackPowerUp = 5;
                enemy.GetComponent<P1Health>().knockbackPower = 8;
            }

            enemy.GetComponent<P1Health>().TakeDamage(attackDamage);
        }

    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
