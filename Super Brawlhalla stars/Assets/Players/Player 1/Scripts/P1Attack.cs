using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Attack : MonoBehaviour
{
    public GameObject hand;
    private P2Health hpScript;
    Animator animat;

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
        hand = GameObject.Find("P1 Hand");
        hpScript = GameObject.Find("Player2").GetComponent<P2Health>();
        animat = GameObject.Find("animator1").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            attackPoint = downAttack;
            

        } else if (Input.GetKey(KeyCode.W))
        {
            attackPoint = upAttack;

        } else {attackPoint = frontAttack;}

        hand.transform.position = attackPoint.position; //draws hand at current attack position

        if (Input.GetKey(KeyCode.H) && attackStat == true)
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
        animat.SetTrigger("Attack1");
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("Succesful hit");
            if (attackPoint == upAttack)
            {
                hpScript.knockbackPowerUp = 10;
                hpScript.knockbackPower = 1;
            } else if (attackPoint == downAttack)
            {
                hpScript.knockbackPowerUp = -2;
                hpScript.knockbackPower = 2;
            } else if (attackPoint == frontAttack)
            {
                hpScript.knockbackPowerUp = 5;
                hpScript.knockbackPower = 8;
            }
            
            hpScript.TakeDamage(attackDamage);
        }

    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
