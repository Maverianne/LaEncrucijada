using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject help;
    public bool damage;
    [Header("Money Counter")]
    public int money;
    public int coinValue;
    public TextMeshProUGUI text;

    [Header("Bars")]
    public int maxLevel = 100;
    public StrenghtBar strenghtBar;
    public SleepBar sleepBar;
    public ReputationBar reputationBar;

    [Header("Strenght Bar")]
    public int currentStrenght;
    public int strenght;

    [Header("Sleep Bar")]
    public int currentSleep;
    public int sleep;

    [Header("Reputation Bar")]
    public GameObject ReputationObj;
    public int currentReputation;
    public int reputation;

    [Header("BossFight")]
    public bool bossFight;
    public GameObject perdiste;
    public int flowers;
    public AudioSource flowerPower;

    [Header("Choices")]
    public bool firstPixie;


    void Awake()
    {
        instance = this;
        //Load Info
        LoadPlayer();
        PlayerData data = SaveSystem.loadPlayer();
        money = data.money;
        text.text = "x" + data.money;
    
        currentStrenght = data.strength;
        currentSleep = data.sleep;
        currentReputation = data.reputation;
    }
    public void Start()
    {
        //Bar
        if (bossFight == false)
        {
            strenghtBar.SetMaxStrenght(maxLevel);
            sleepBar.SetMaxSleep(maxLevel);
            reputationBar.SetMaxReputation(maxLevel);

            strenghtBar.setStrenght(currentStrenght);
            sleepBar.setSleep(currentSleep);
            reputationBar.setReputation(currentReputation);
            flowers = 0;
        }
        if (bossFight == true)
        {
            currentStrenght = 100;
            strenghtBar.SetMaxStrenght(maxLevel);
            strenghtBar.setStrenght(currentStrenght);
            currentReputation = 0;
        }
    }
    public void Update()
    {
        BossFighting();
        ChangeScore();
        //Disminuye Barras si es true en la escena
        if (damage == true)
        {
            StartCoroutine("Damage");
            strenghtBar.setStrenght(currentStrenght);
            sleepBar.setSleep(currentSleep);
            reputationBar.setReputation(currentReputation);
        }
        else
        {
            strenghtBar.setStrenght(currentStrenght);
            sleepBar.setSleep(currentSleep);
            reputationBar.setReputation(currentReputation);
        }
        if (currentSleep <= 0 || currentStrenght <= 0)
        {
            //Debug.Log("Perdiste");
        }
        if (currentSleep <= 0)
        {
            currentSleep = 0;
        }
        if (currentReputation <= 0)
        {
            currentReputation = 0;
        }
        if (currentStrenght <= 0)
        {
            currentStrenght = 0;
        }
        if (currentSleep >= 100)
        {
            currentSleep = 100;
        }
        if (currentReputation >= 100)
        {
            currentReputation = 100;
        }
        if (currentStrenght >= 100)
        {
            currentStrenght = 100;
        }
        if(currentReputation == 0)
        {
            ReputationObj.SetActive(false);
        }
        else
        {
            ReputationObj.SetActive(true);
        }

    }
    public void BossFighting()
    {
        if (bossFight)
        {
            if(currentStrenght == 0)
            {
                perdiste.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.V) && flowers == 1) 
        {
            Flower();
            flowers = 0;
            flowerPower.Play();
        }
        else
        {
            return;
        }
    }
    public void FirstPixie() {
        if (firstPixie)
        {
            money -= 50 ;
            print("FairyCharge");
            SavePlayer();
        }
        else
        {
            return;
        }
    }
    public void Flower()
    {
        currentStrenght = 100;
        Destroy(help);
    }
    public void Beginning()
    {
        SaveSystem.Reset(this);
        Debug.Log("Reset");
        LoadingGame.instance.LoadScene(0);
    }
    public void FightAgain()
    {
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("Again");
        SceneManager.LoadScene(scene.name);
    }
    public void Nimph()
    {
        money = 1000;
    }   
    public void ChangeScore()
    {
        text.text = "x" + money.ToString();
    }
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.loadPlayer();
        money = data.money;
    }
    //ResetInfo;
    public void Reset()
    {
        SaveSystem.Reset(this);
        Debug.Log("Reset");
        LoadingGame.instance.LoadScene(1);
    }
    public IEnumerator Damage()
    {
        yield return new WaitForSeconds(3f);
        currentStrenght -= 2;
        currentSleep -= 2;
        StopCoroutine("Damage");
    }
}
