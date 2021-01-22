using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public int hit;
    public int resistance;
    public bool canHurt;
    public GameObject Daddy; 

    private void Start()
    {
        hit = 0;
    }
    private void Update()
    {
        if(canHurt && Input.GetKeyDown(KeyCode.E))
        {
            hit += 1;
        }
        if(hit >= resistance)
        {
            Destroy(Daddy);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            canHurt = true;
        }
        if (collision.gameObject.tag == "NoReturn")
        {
            Daddy.SetActive(false);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            canHurt = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canHurt = false;
        }
    }
}
