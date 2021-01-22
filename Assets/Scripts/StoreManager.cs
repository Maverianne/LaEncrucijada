using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StoreManager : MonoBehaviour
{
    [Header("Store Array")]
    public GameObject[] Products;
    public int[] price;
    public TextMeshProUGUI hello;
    public TextMeshProUGUI[] text;
    public TextMeshProUGUI Puntos; 
    public TextMeshProUGUI discountP1;
    public TextMeshProUGUI discountP2;
    public TextMeshProUGUI discountP3;

    [Header("GameObjects")]
    public GameObject wow;
    public GameObject myStore;
    public GameObject myName;

    [Header("Choose Store")]
    public bool canOpen;
    public bool NotRep;
    public bool Store, Rest, Burdel, Cantina, Comedor;
    public bool Two, One, Three;

    [Header("Rest")]
    public bool changeScene;
    public bool decision;
    public bool playsVideo;

    [Header("Extras")]
    public int discount;
    public int SceneNumber;
    public bool bought;
    public AudioSource clic;
    public AudioSource buying;

    public void Start()
    {
        myStore.SetActive(false);
        myName.SetActive(false);
        Puntos.text = "";
    }
    public void Update()
    {
        if(GameManager.instance.currentReputation == 0 && Burdel == true || GameManager.instance.currentReputation == 0 && Cantina == true)
        {
            NotRep = true;
            myStore.SetActive(false);
        }
        else
        {
            NotRep = false;
        }
        if(NotRep == false) { 

            if (canOpen == true && Input.GetKey(KeyCode.Q))
            {
                myStore.SetActive(true);
                Hello();
            }
        }
        else
        {
            canOpen = false;
        }
        if (One)
        {
            text[0].text = "$" + (price[0] - discount);
        }
        if (Two)
        {
            text[0].text = "$" + (price[0] - discount);
            text[1].text = "$" + (price[1] - discount);
        }
        if (Three)
        {
            text[0].text = "$" + (price[0] - discount);
            text[1].text = "$" + (price[1] - discount);
            text[2].text = "$" + (price[2] - discount);
        }
        if (Burdel)
        {
            One = true;
        }
        if (Rest)
        {
            Two = true;
        }
        if(Cantina || Comedor)
        {
            Three = true;
        }
      
    }
    public void Hello()
    {
        if (Store)
        { 
            if (GameManager.instance.currentReputation >= 70)
            {
                StopCoroutine("BlankSpace");
                hello.text = "¡Aventurero! Que honor que entres a mi humilde negocio. Por favor pregunta acerca de lo que gustes";
                Puntos.text = "";
                StartCoroutine("BlankSpace");
            }
            if (GameManager.instance.currentReputation < 70)
            {
                StopCoroutine("BlankSpace");
                hello.text = "¡Bienvenido forastero! Pasa y deléitate con mis fórmulas y pociones. Pregunta lo que gustes ";
                Puntos.text = "";
                StartCoroutine("BlankSpace");
            }
        }
        if (Rest)
        {
            if (GameManager.instance.currentReputation >= 70)
            {
                StopCoroutine("BlankSpace");
                hello.text = "¡Aventurero! Que agradable que visite este humilde hostal. Si desea quedarse le ofrezco mi mejor habitación.";
                Puntos.text = "";
                StartCoroutine("BlankSpace");
            }
            if (GameManager.instance.currentReputation < 70)
            {
                StopCoroutine("BlankSpace");
                hello.text = "Buenas noches joven. ¿Busca un lugar donde pasar la noche cómodamente y reponer energía? ";
                Puntos.text = "";
                StartCoroutine("BlankSpace");
            }
        }
        if (Burdel)
        {
            if (GameManager.instance.currentReputation >= 70)
            {
                StopCoroutine("BlankSpace");
                hello.text = "Hola guapo. Hemos estado esperando tu llegada. Todos son tan aburridos por aquí, pasa y ponte cómodo.";
                Puntos.text = "";
                StartCoroutine("BlankSpace");
            }
            if (GameManager.instance.currentReputation < 70)
            {
                StopCoroutine("BlankSpace");
                hello.text = "Hola muchacho. ¿Qué te trae por aquí? Estás lejos de casa ¿Cierto? ¿No quieres pasar y relajarte un rato?";
                Puntos.text = "";
                StartCoroutine("BlankSpace");
            }
        }
        if (Cantina)
        {
            if (GameManager.instance.currentReputation >= 70)
            {
                StopCoroutine("BlankSpace");
                hello.text = "¡Eres tú! Qué gusto que estés acá. Bienvenido aventurero, toma asiento y siéntete como en casa. Pide lo que gustess";
                Puntos.text = "";
                StartCoroutine("BlankSpace");
            }
            if (GameManager.instance.currentReputation < 70)
            {
                StopCoroutine("BlankSpace");
                hello.text = "Hola muchacho. No pareces de por aquí, ven siéntate y toma un trago. Estás en el mejor sitio para convivir con los locales.";
                Puntos.text = "";
                StartCoroutine("BlankSpace");
            }
        }
        if (Comedor)
        {
            if (GameManager.instance.currentReputation >= 70)
            {
                StopCoroutine("BlankSpace");
                hello.text = "¡Dios mío, es el gran aventurero del que todos hablan! Pasa por favor, siéntate, debes estar hambriento. ¿Qué te puedo preparar?";
                Puntos.text = "";
                StartCoroutine("BlankSpace");
            }
            if (GameManager.instance.currentReputation < 70)
            {
                StopCoroutine("BlankSpace");
                hello.text = "Querido muchacho, pasa. Pareces hambriento, siéntate y pregunta por las opciones que tenemos.";
                Puntos.text = "";
                StartCoroutine("BlankSpace");
            }
        }
        if (GameManager.instance.currentReputation >= 70)
        {
            discount = 3;
            discountP1.text = "-" + discount;
            discountP2.text = "-" + discount;
            discountP3.text = "-" + discount;
        }
        if (GameManager.instance.currentReputation < 70 && GameManager.instance.currentReputation > 0)
        {
            discount = 0;
            discountP1.text = "" + discount;
            discountP2.text = "" + discount;
            discountP3.text = "" + discount;
        }
        if (GameManager.instance.currentReputation == 0)
        {
            discount = -5;
            discountP1.text = "+5";
            discountP2.text = "+5";
            discountP3.text = "+5";
        }
    }
    public void OpenStore()
    {
        myStore.SetActive(true);
        Hello();
    }
    public void Buy1()
    {
        if (GameManager.instance.money >= price[0] - discount)
        {
            buying.Play();
            StopCoroutine("BlankSpace");
            hello.text = "Gracias por tu compra";
            Puntos.text = "";
            StartCoroutine("BlankSpace");
            GameManager.instance.money = GameManager.instance.money - (price[0] - discount);
            Products[0].SetActive(false);
            if (Store == true)
            {
                GameManager.instance.currentStrenght = GameManager.instance.currentStrenght + 25;
            }
            if (Burdel == true)
            {
                GameManager.instance.currentReputation = GameManager.instance.currentReputation + 10;
                bought = true;
            }
            if (Cantina == true)
            {
                GameManager.instance.currentReputation = GameManager.instance.currentReputation + 3;
                bought = true;
            }
            if (Rest == true)
            {
                GameManager.instance.currentSleep = GameManager.instance.currentSleep + 30;
                if (decision)
                {
                    ChooseVideo.instance.chooseNow = true;
                    GameManager.instance.SavePlayer();
                    GameManager.instance.FirstPixie();
                }
                if (changeScene)
                {
                    EndDay();
                    GameManager.instance.FirstPixie();
                }
                if (playsVideo)
                {
                    GameManager.instance.FirstPixie();
                }
            }
            if (Comedor == true)
            {
                GameManager.instance.currentStrenght = GameManager.instance.currentStrenght + 5;
            }
        }
        else
        {
            StopCoroutine("BlankSpace");
            hello.text = "No tienes suficiente dinero";
            Puntos.text = "";
            StartCoroutine("BlankSpace");
        }

    }
    public void Buy2()
    {
        buying.Play();
        if (GameManager.instance.money >= price[1] - discount)
        {
            StopCoroutine("BlankSpace");
            hello.text = "Gracias por tu compra";
            Puntos.text = "";
            StartCoroutine("BlankSpace");

            GameManager.instance.money = GameManager.instance.money - (price[1] - discount);

            Products[1].SetActive(false);
            if (Store == true)
            {
                GameManager.instance.currentStrenght = GameManager.instance.currentStrenght + 30;
                GameManager.instance.currentSleep = GameManager.instance.currentSleep + 10;

            }
            if (Cantina == true)
            {
                GameManager.instance.currentReputation = GameManager.instance.currentReputation + 6;
                bought = true;
            }
            if (Rest == true)
            {
                GameManager.instance.currentSleep = GameManager.instance.currentSleep + 30;
                GameManager.instance.currentStrenght = GameManager.instance.currentStrenght + 20;
                if (decision)
                {
                    ChooseVideo.instance.chooseNow = true;
                    GameManager.instance.SavePlayer();
                    GameManager.instance.FirstPixie();
                }
                if (changeScene)
                {
                    EndDay();
                    GameManager.instance.FirstPixie();
                }
                if(playsVideo)
                {
                    GameManager.instance.SavePlayer();
                    TriggerVideo.instance.playNow = true;
                    GameManager.instance.FirstPixie();
                }
            }
            if (Comedor == true)
            {
                GameManager.instance.currentStrenght = GameManager.instance.currentStrenght + 8;
            }
        }
        else
        {
            StopCoroutine("BlankSpace");
            hello.text = "No tienes suficiente dinero";
            Puntos.text = "";
            StartCoroutine("BlankSpace");
        }
    }
    public void Buy3()
    {
        buying.Play();
        if (GameManager.instance.money >= price[2] - discount)
        {
            StopCoroutine("BlankSpace");
            hello.text = "Gracias por tu compra";
            Puntos.text = "";
            StartCoroutine("BlankSpace");
            GameManager.instance.money = GameManager.instance.money - (price[2] - discount);

            Products[2].SetActive(false);
            if (Cantina == true)
            {
                GameManager.instance.currentReputation = GameManager.instance.currentReputation + 9;
                bought = true;
            }
            if (Comedor == true)
            {
                GameManager.instance.currentStrenght = GameManager.instance.currentStrenght + 10;
            }
        }
        else
        {
            StopCoroutine("BlankSpace");
            hello.text = "No tienes suficiente dinero";
            Puntos.text = "";
            StartCoroutine("BlankSpace");
        }
    }
    public void Ask1()
    {
        clic.Play();
        if (Store)
        {
            StopCoroutine("BlankSpace");
            hello.text = "Es la favorita de los aventureros para recuperar la fuerza perdida";
            Puntos.text = "+25F";
                StartCoroutine("BlankSpace");
        }
        if (Rest)
        {
            StopCoroutine("BlankSpace");
            hello.text = "Clásica, con un buen colchón limpio y una habitación silenciosa";
            Puntos.text = "+30V";
            StartCoroutine("BlankSpace");
        }
        if (Burdel)
        {
            hello.text = "Conmigo y las demás chicas. Te vas a relajar mucho, lo prometo";
            Puntos.text = "+10R";
            StartCoroutine("BlankSpace");
        }
        if (Cantina)
        {
            StopCoroutine("BlankSpace");
            hello.text = "¡Es la mejor cerveza obscura del pueblo! Refrescante y robusta";
            Puntos.text = "+3R";
            StartCoroutine("BlankSpace");
        }
        if (Comedor)
        {
            StopCoroutine("BlankSpace");
            hello.text = "Excelente opción para cuando no tienes mucha hambre…u oro";
            Puntos.text = "+5F";
            StartCoroutine("BlankSpace");
        }
    }
    public void Ask2()
    {
        clic.Play();
        if (Store)
        {
            StopCoroutine("BlankSpace");
            hello.text = "Hecha con hadas reales. Es como tener vida extra en una botella";
            Puntos.text = "+30 F  +10V";
            StartCoroutine("BlankSpace");
        }
        if (Rest)
        {
            StopCoroutine("BlankSpace");
            hello.text = "Ideal para partir temprano, con un moderado desayuno incluido";
             Puntos.text = "+30 V +20F";
            StartCoroutine("BlankSpace");
        }
        if (Cantina)
        {
            StopCoroutine("BlankSpace");
            hello.text = "Exquisito, importado de tierras muy lejanas. Una fina opción";
             Puntos.text = "+6R";
            StartCoroutine("BlankSpace");
        }
        if (Comedor)
        {
            StopCoroutine("BlankSpace");
            hello.text = "El favorito de los comensales. Siempre disponible.";
             Puntos.text = "+8F";
            StartCoroutine("BlankSpace");
        }
    }
    public void Ask3()
    {
        clic.Play();
        if (Store)
        {
            StopCoroutine("BlankSpace");
            hello.text = "Recién traidas. Acompañantes perfectas para cualquier misión";
            Puntos.text = "";
            StartCoroutine("BlankSpace");
        }
        if (Cantina)
        {
            StopCoroutine("BlankSpace");
            hello.text = "Solo los hombres más fuertes toman aguardiente de esta clase ";
             Puntos.text = "+9R";
            StartCoroutine("BlankSpace");
        }
        if (Comedor)
        {
            StopCoroutine("BlankSpace");
            hello.text = "Una comida balanceada: entrada, plato fuerte y complementos.";
            Puntos.text = "+10F";
            StartCoroutine("BlankSpace");
        }
    }
    public void EndDay()
    {
        GameManager.instance.SavePlayer();
        LoadingGame.instance.LoadScene(SceneNumber);
    }
    public void EndTransaction()
    {
        myStore.SetActive(false);
        clic.Play();
        if (Cantina && bought || Burdel && bought)
        {
            wow.SetActive(true);
            bought = false;
            StartCoroutine("ByeBye");
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            canOpen = true;
            myName.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            canOpen = false;
            myName.SetActive(false);
        }
    }
    public IEnumerator BlankSpace()
    {
        yield return new WaitForSeconds(5f);
        hello.text = "";
        Puntos.text = "";
    }
    IEnumerator ByeBye()
    {
        yield return new WaitForSeconds(2f);
        wow.SetActive(false);
    }
}
