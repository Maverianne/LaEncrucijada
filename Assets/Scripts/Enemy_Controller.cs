using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
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
    private void Update()
    {
        if (inRange)
        {
            hit = Physics2D.Raycast(rayCast.position, Vector2.left, rayCastLenght, raycastMask);
            RayCastDebugger();
            anim.SetBool("canWalk", true);
        }

        if (hit.collider != null)
        {
            EnemyLogic();
        }
        else if (hit.collider == null)
        {
            inRange = false;
        }
        if (inRange == false)
        {
            anim.SetBool("canWalk", false);
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
    void CoolDown()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 && cooling && attackMode)
        {
            cooling = false;
            timer = inTimer;
        }
    }
    void RayCastDebugger()
    {
        if (distance > attackDistance)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * rayCastLenght, Color.red);
        }
        else if (attackDistance > distance)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * rayCastLenght, Color.green);
        }
    }
    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);
        if (distance > attackDistance)
        {
            Move();
            StopAttack();
        }
        else if (attackDistance >= distance && cooling == false)
        {
            Attack();
            anim.SetTrigger("attack");
        }
        if (cooling)
        {
            CoolDown();
        }
    }
    void Move()
    {
        Vector2 targetPosition = new Vector2(target.transform.position.x, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
    void Attack()
    {
        timer = inTimer;
        attackMode = true;
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
