using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class ChooseVideo : MonoBehaviour
{
    public static ChooseVideo instance;
    public RawImage rawImage;
    public GameObject intro, game, choose;
    public VideoPlayer videoPlayer;
    public float videoLenght;
    public bool chooseNow, picked1, picked2, want1, want2, nimph1, nimph2;
    public float wait;
    public int sceneNum;

    public GameObject bundle;

    [Header("Choices")]
    public bool nimph;
    public bool pixie;
    public bool witch;
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        intro.SetActive(false);
        choose.SetActive(false);
        chooseNow = false;
        picked1 = false;
        picked2 = false;
        want1 = false;
        want2 = false;

    }
    public void Update()
    {
        if (picked1)
        {
            TriggerVideo.instance.playNow = true;
            choose.SetActive(false);
            if (nimph)
            {
                GameManager.instance.Nimph();     
            }
            if (pixie)
            {
                GameManager.instance.currentSleep= 90;
                GameManager.instance.currentStrenght = 90;
            }
            if (witch)
            {
                GameManager.instance.currentReputation = 0;
            }
        }
        if (picked2)
        {

            TriggerVideoB.instance.playNow = true;
            choose.SetActive(false);
            if (pixie)
            {
                if (GameManager.instance.currentSleep < 70) { 
                    GameManager.instance.currentSleep = 70;
                }
                if (GameManager.instance.currentStrenght < 70)
                {
                    GameManager.instance.currentStrenght = 70;
                }
            }
        }
        if (want2)
        {
            SceneManager.LoadScene(sceneNum);
        }
        if (want1)
        {
            game.SetActive(true);
            bundle.SetActive(false);
            choose.SetActive(false);
        }
        if (nimph1)
        {
            choose.SetActive(false);
            bundle.SetActive(false);
            NimphTrigger.instance.playNow = true;
        }
        if (nimph2)
        {
            choose.SetActive(false);
            bundle.SetActive(false);
            NimphTrigger2.instance.playNow = true;
        }
    }
    public void FixedUpdate()
    {
        if (chooseNow)
        {
            StartCoroutine(PlayVideo());
            StartCoroutine("VideoEnded");
            intro.SetActive(true);
        }
        
    }
   public void Choose1()
    {
        picked1 = true;
    }
    public void Choose2()
    {
        picked2 = true;
    }
    public void noVideo1()
    {
        want1 = true;
    }

    public void noVideo2()
    {
        want2 = true;
    }
    public void Nimph1()
    {
        nimph1 = true;
    }
    public void Nimph2()
    {
        nimph2 = true; 
    }

    IEnumerator PlayVideo()
    {

        videoPlayer.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(wait);
        while (!videoPlayer.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }
        videoPlayer.Play();
        rawImage.texture = videoPlayer.texture;
        intro.SetActive(true);
        game.SetActive(false);
    }
    IEnumerator VideoEnded()
    {
        yield return new WaitForSeconds(videoLenght);
        videoPlayer.Pause();
        choose.SetActive(true);
        rawImage.texture = null;
        intro.SetActive(false);
        chooseNow = false;
        StopCoroutine("VideoEnded");
    }
}
