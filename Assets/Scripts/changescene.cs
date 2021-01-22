using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changescene : MonoBehaviour
{
    public int SceneNumber;
    public bool restore;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.SavePlayer();
            LoadingGame.instance.LoadScene(SceneNumber);
            if (restore)
            {
                GameManager.instance.currentStrenght = 100;
                GameManager.instance.currentSleep = 100;

            }
        }
    }
}
