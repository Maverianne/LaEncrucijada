using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrenghtBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxStrenght(int strenght)
    {
        slider.maxValue = strenght;
        slider.value = strenght;
    }

    public void setStrenght(int strenght)
    {
        slider.value = strenght;
    }
}
