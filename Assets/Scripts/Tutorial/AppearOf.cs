using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearOf : MonoBehaviour
{
    public GameObject Instructions;
    public GameObject card;
    public AudioSource closing; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            card.SetActive(true);
        }
    }
    public void Close()
    {
        closing.Play();
        Instructions.SetActive(false);
        
    }

}
