using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBoss : MonoBehaviour
{

    public BossHealth Boss;

    public void AttackingBoss()
    {
        if (PlayerController.instance.canAttack)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Boss.currentHealth -= 3;
                print("HitBoss");
            }
        }
    }
}
