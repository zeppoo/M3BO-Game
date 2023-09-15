using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Getattackerposition : MonoBehaviour
{
    int attackPosition = 0;
    public Transform attacker;
    public int GetAttackerPosition()
    {
        if (attacker.position.x < transform.position.x)
        {
            attackPosition = 1;
        }
        else if (attacker.position.x > transform.position.x)
        {
            attackPosition = -1;
        }
        return attackPosition;
    }
}
