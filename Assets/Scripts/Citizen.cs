using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Citizen : MonoBehaviour
{
    public TextMeshProUGUI hello;
    public GameObject openTalk;
    public bool canTalk;
    public int text;
    public bool changeLine;
    public bool Bard;
    public bool citizen1;
    public bool citizen2;
    public bool citizen3;
    public bool citizen4;
    public bool weirdStore;
    void Start()
    {
        openTalk.SetActive(false);
        hello.text = "";
    }
    private void FixedUpdate()
    {
        if (canTalk && Input.GetKeyDown(KeyCode.Q))
        {
            openTalk.SetActive(true);
            if (citizen1)
            {
                Guy1();
            }
            if (citizen2)
            {
                Guy2();
            }
            if (citizen3)
            {
                Guy3();
            }
            if (citizen4)
            {
                Guy4();
            }
            if (Bard)
            {
                Singing();
            }
        }
    }
    void Singing()
    {
        if (GameManager.instance.currentReputation <= 0)
        {
            hello.text = "¿Y tú quién eres? No me molestes, tengo canciones que componer de verdaderas aventuras";
        }
        if (GameManager.instance.currentReputation <= 50 && GameManager.instance.currentReputation > 0)
        {
            hello.text = "Hola joven aventurero ¿Eres nuevo por aquí? Estaré atento a lo que hagas, tal vez valga la pena componer canciones sobre ti.";
        }   
        if (GameManager.instance.currentReputation >= 51 && GameManager.instance.currentReputation < 70)
        {
            hello.text = "Realmente eres un aventurero como ningun otro, casí termino de escribir tu canción";
        }
        if (GameManager.instance.currentReputation >= 70)
        {
            hello.text = "¡Hola Aventurero! He anunciado tu llegada, el pueblo te espera con entusiasmo";
        }
    }
    void Guy1()
    {
        if (weirdStore)
        {
            hello.text = "¿Ahora dónde comprare mis medicinas? hadas irrespetuosas";
        }
        if (weirdStore == false)
        {
            if (GameManager.instance.currentReputation <= 0)
            {
                hello.text = "...";
            }
            if (GameManager.instance.currentReputation < 70 && GameManager.instance.currentReputation > 0)
            {
                hello.text = "Hola, bienvenido a nuestro humilde Pueblo";
            }
            if (GameManager.instance.currentReputation >= 70)
            {
                hello.text = "¡No puede ser, eres tú! El bardo anunció tu llegada";
            }
        }
    }
    void Guy2()
    {
        if (weirdStore)
        {
            hello.text = "Esas hadas se están volviendo locas";
        }
        if(weirdStore == false) { 
            if (GameManager.instance.currentReputation <= 0)
            {
                hello.text = "Hm...";
            }
            if (GameManager.instance.currentReputation < 70 && GameManager.instance.currentReputation > 0)
            {
                hello.text = "Un gusto concerte";
            }
            if (GameManager.instance.currentReputation >= 70)
            {
                hello.text = "Es un gusto tener a tan grande aventurero entre nosotros";
            }
        }
    }
    void Guy3()
    {
        if (GameManager.instance.currentReputation <= 0)
        {
            hello.text = "¿Qué me ves forastero?";
        }
        if (GameManager.instance.currentReputation < 70 && GameManager.instance.currentReputation > 0)
        {
            hello.text = "Si quieres descansar, puedes hacerlo en el hostal";
        }
        if (GameManager.instance.currentReputation >= 70)
        {
            hello.text = "Alguien como tú seguro recibe grandes descuentos en las tiendas";
        }
    }
    void Guy4()
    {
        if (GameManager.instance.currentReputation <= 0)
        {
            hello.text = "Alejate de mi o llamare a los guardias";
        }
        if (GameManager.instance.currentReputation < 70 && GameManager.instance.currentReputation > 0)
        {
            hello.text = "Es un gusto recibir a nuevos aventureros, las buenas costumbres no se pierden";
        }
        if (GameManager.instance.currentReputation >= 70)
        {
            hello.text = "Espero poder llegar a ser como tú algun día";
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            canTalk = true;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            hello.text = "";
            openTalk.SetActive(false);
            canTalk = false;
        }
    }
}
