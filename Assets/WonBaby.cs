using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WonBaby : MonoBehaviour
{
    public GameObject S1;
    public GameObject S2;
    public void Start()
    {
        S1.SetActive(true);
        S2.SetActive(false);
    }
    public void Change()
    {
        S1.SetActive(false);
        S2.SetActive(true);
    }
    public void Beginning()
    {
        GameManager.instance.Beginning();
    }
    public void Blog()
    {
        Application.OpenURL("https://www.youtube.com/watch?v=zg6KuBUXXWo");
    }
}
