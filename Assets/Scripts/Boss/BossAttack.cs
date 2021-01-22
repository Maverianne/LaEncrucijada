using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{

    public int attackDamage = 20;
    public int enragedAttackDamage = 30;


    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;


    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            Debug.Log("Hitt");
            GameManager.instance.currentStrenght -= attackDamage;
        }
    }

    public void EnragedAttack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;
        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            GameManager.instance.currentStrenght -= enragedAttackDamage;
            Debug.Log("Hitt");
        }
    }

    void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Gizmos.DrawWireSphere(pos, attackRange);
    }
    //public int attackDamage = 10;
    //public int enragedDamage = 13;
    //public Transform attackPoint;
    ////public GameObject AttackHere;
    //public float attackRange = 0.5f;
    //public LayerMask playerLayer;

    //public Vector3 attackOffset;
    //public LayerMask attackMask;
    //public bool canAttack;
    //public void Start()
    //{
    //    //attackPoint.position = AttackHere.transform.position;
    //}
    //public void Attack()
    //{

    //    //if (canAttack)
    //    //{
    //    //    GameManager.instance.currentStrenght -= attackDamage;
    //    //    print("Hit");
    //    //}
    //    //detect enemies
    //    Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer); 

    //    foreach(Collider2D enemy in hitEnemies)
    //    {
    //        GameManager.instance.currentStrenght -= attackDamage;
    //        print("Hit");
    //    }
    //}
    //public void EnragegAttack()
    //{
    //        GameManager.instance.currentStrenght -= enragedDamage;
    //        print("Hit");
    //}
    //void OnDrawGizmos()
    //{
    //    //if (attackPoint = null)
    //    //{
    //    //    return;
    //    //}
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(attackPoint.position, attackRange);

    //}
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Attack"))
    //    {
    //        canAttack = true;
    //    }
    //}
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Attack"))
    //    {
    //        canAttack = false;
    //    }
    //}
}
