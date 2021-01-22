using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyHeal : MonoBehaviour
{
    public GameObject pixie;
    public int heal;
    public int maxHeal;
    public Animator anim;
    public AudioSource healing; 

    private void Update()
    {
        if (heal <= maxHeal)
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                anim.SetTrigger("Heal");
                healing.Play();
                heal += 1;
                pixie.SetActive(false);
                GameManager.instance.currentStrenght += 18;
                GameManager.instance.currentSleep += 18;
            }
        }
    }
}