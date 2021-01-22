using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TiendaReves : MonoBehaviour
{
    public TextMeshProUGUI sorry;
    public GameObject openTalk;
    public bool canTalk;
    public int text;
    public bool changeLine;
    void Start()
    {
        openTalk.SetActive(false);  
    }
    private void FixedUpdate()
    {
        if(canTalk && Input.GetKeyDown(KeyCode.Q)) {
            openTalk.SetActive(true);
            if (text == 0 && changeLine)
            {
                sorry.text = "Lo siento ahora no estamos abiertos...";
                text = 1;
                changeLine = false;
                StartCoroutine("WaitForchange");
            }
            else if (text == 1 && changeLine)
            {
                sorry.text = "Esas malditas hadas rebeldes volteron la tienda...";
                text = 2;
                changeLine = false;
                StartCoroutine("WaitForchange");
            }
            else if (text == 2 && changeLine)
            {
                sorry.text = "Si estan inconformes deberían externarlo de otra manera...";
                text = 3;
                changeLine = false;
                StartCoroutine("WaitForchange");
            }
           else if (text == 3 && changeLine)
            {
                sorry.text = "Estas no son formas de expresarse.";
                text = 4;
                changeLine = false;
                StartCoroutine("WaitForchange");
            }
            else if (text == 4 && changeLine)
            {
                sorry.text = "...";
                text = 4;
                changeLine = false;
            }
        }
    }
    public IEnumerator WaitForchange()
    {
        yield return new WaitForSeconds(.5f);
        changeLine = true;

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            canTalk= true;
            text = 0;
            changeLine = true;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            openTalk.SetActive(false);
            canTalk = false;
            text = 0;
            changeLine = false;
        }
    }
}
