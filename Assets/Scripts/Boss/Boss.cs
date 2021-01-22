using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public static Boss instance;
    Boss_Run bossRun;
    public Animator anim;
    public Transform player;
    public bool isFlipped = false;
    public bool canTurn = true;
    public int attack;
    public bool enraged;
    public void Start()
    {
        canTurn = true;
    }
    public void LookAtPlayer()
    {
        if (!enraged)
        {
            attack = 5;
        }

        if (enraged)
        {
            attack = 3;
        }
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;
        if (canTurn) {
            StopCoroutine("Turn");
            StartCoroutine("Turn");
            if (transform.position.x > player.position.x && isFlipped)
            {
            
                transform.localScale = flipped;
                transform.Rotate(0f, 180f, 0f);
                isFlipped = false;
            }
            if (transform.position.x < player.position.x && !isFlipped)
            {
                transform.localScale = flipped;
                transform.Rotate(0f, 180f, 0f);
                isFlipped = true;
            }        
            canTurn = false;
        }
    }
    IEnumerator Turn()
    {
        yield return new WaitForSeconds(attack);
        canTurn = true;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Attack"))
        {
            anim.SetTrigger("Attack");
        }
    }
}
