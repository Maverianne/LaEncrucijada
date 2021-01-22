using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fairycoins : MonoBehaviour
{
    public AudioSource coin;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Pixie")
        {
            GameManager.instance.money = GameManager.instance.money + 15;
            coin.Play();
            gameObject.SetActive(false);
            PixieController.instance.follow = true;
            PixieController.instance.collected += 1;
        }
        if (col.gameObject.tag == "NoReturn")
        {
            gameObject.SetActive(false);
            PixieController.instance.follow = true;
            PixieController.instance.collected += 1;
        }
    }
}
