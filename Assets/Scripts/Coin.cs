using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 10;
    public bool ImOne;
    public bool gotMe;
    public AudioSource grab;
    public void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            GameManager.instance.money = GameManager.instance.money += 10;
            gameObject.SetActive(false);
            grab.Play();
        }
        if (col.gameObject.tag == "NoReturn")
        {
            gameObject.SetActive(false);
        }

    }
}
