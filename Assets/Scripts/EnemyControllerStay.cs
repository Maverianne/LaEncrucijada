using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerStay : MonoBehaviour
{
    #region Public Variables
    public Transform rayCast;
    public LayerMask raycastMask;
    public float rayCastLenght;
    public float attackDistance;
    public float moveSpeed;
    public float timer;
    public Animator anim;
    public int Hits;
    #endregion

    #region Private Variables
    private RaycastHit2D hit;
    private GameObject target;
    private float distance;
    private bool attackMode;
    public bool inRange;
    public bool cooling;
    private float inTimer;
    #endregion


    private void Awake()
    {
        inTimer = timer;

    }
    private void FixedUpdate()
    {
        if (inRange && cooling == false)
        {
            Attack();
        }
        if (inRange == false)
        {
            StopAttack();
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            target = collision.gameObject;
            inRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            target = collision.gameObject;
            inRange = false;
        }
    }
    void CoolDown()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 && cooling && attackMode)
        {
            cooling = false;
            timer = inTimer;
        }
    }
    //void EnemyLogic()
    //{
    //    distance = Vector2.Distance(transform.position, target.transform.position);
    //    if (distance > attackDistance)
    //    {
    //        StopAttack();
    //    }
    //    else if (attackDistance >= distance && cooling == false)
    //    {
    //        Attack();
    //        anim.SetTrigger("attack");
    //    }
    //    if (cooling)
    //    {
    //        CoolDown();
    //    }
    //}
    void Attack()
    {
        timer = inTimer;
        attackMode = true;
        anim.SetTrigger("attack");
        GameManager.instance.currentStrenght -= 5;
        TriggerCooling();
    }
    void StopAttack()
    {
        cooling = false;
        attackMode = false;
    }
    public void TriggerCooling()
    {
        cooling = true;
    }
}
