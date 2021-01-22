using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public AudioSource attack;

    public void Attacking()
    {
        attack.Play();
    }
}
