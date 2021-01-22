using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImTrigger : MonoBehaviour
{
    public bool restore;
    public bool video, choice, nimph;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (video)
            {
                GameManager.instance.SavePlayer();
                TriggerVideo.instance.playNow = true;
                if (nimph)
                {
                    GameManager.instance.Nimph();
                }
            }
         
            if (choice)
            {
                ChooseVideo.instance.chooseNow = true;
                GameManager.instance.SavePlayer();
            }

            if (restore)
            {
                GameManager.instance.currentStrenght = 100;
                GameManager.instance.SavePlayer();
                GameManager.instance.currentSleep = 100;

            }
        }
    }
}
