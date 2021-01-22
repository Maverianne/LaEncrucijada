using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReputationBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxReputation(int reputation)
    {
        slider.maxValue = reputation;
        slider.value = reputation;
    }

    public void setReputation(int reputation)
    {
        slider.value = reputation;
    }
}
