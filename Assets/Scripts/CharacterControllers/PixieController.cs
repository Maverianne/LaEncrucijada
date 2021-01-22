using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixieController : MonoBehaviour
{
    public static PixieController instance;
    [Header("Action")]
    public Vector2 playerpos;
    public float lookradious;

    public bool attack, collect, follow;
    public bool day3, day4; 
    public Transform player;
    public float moveSpeed;
    public bool fairy2;
    public bool GotOne;
    public int power;
    public int collected;
    public int sceneCoins;
    public int currentCoin;

    public GameObject[] coins;
    public void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        sceneCoins = 7;
        player = GameObject.FindWithTag("Player").transform;
        if (GameManager.instance.currentReputation <= 60)
        {
            moveSpeed = 7f;
            power = 10;
        }
        if (GameManager.instance.currentReputation >= 60 || day3)
        {
            lookradious = 4;
            moveSpeed = 5f;
            power = 7;
        }
        if (GameManager.instance.currentReputation >= 80 || day4)
        {
            lookradious = 2;
            moveSpeed = 3f;
            power = 5;
        }
        if (fairy2)
        {
            lookradious = 3;
            moveSpeed = 4f;
            power = 6;
        }
        follow = true;
        collected = 0;
    }

    // Update is called once per frame
    void Update()
    {
      
        playerpos = new Vector2(playerpos.x = player.position.x - 1.5f, playerpos.y = player.position.y + 1.5f);
        if (follow)
        {
            {
                transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), playerpos, moveSpeed * Time.deltaTime);
            }
        }

        //follow = false;
        if (collect)
        {
            FindCoins();
        }
        else
        {
            return;
        }
    }
    void FindCoins()
    {
        if (coins[collected] != null)
        {
            float distance = Vector2.Distance(coins[collected].transform.position, transform.position);
            if (distance <= lookradious)
            {
                transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), coins[collected].transform.position, moveSpeed * Time.deltaTime);
                follow = false;
            }
            else
            {
                follow = true;
            }
            if (!coins[collected].activeInHierarchy)
            {
                follow = true;
                coins[collected] = null;
            }
        }
        else
        {
            return;
        }

        if(collected >= sceneCoins)
        {
            collect = false;
        }
       
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookradious);
    }
}
