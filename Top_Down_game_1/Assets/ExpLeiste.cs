using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpLeiste : MonoBehaviour
{
    public Slider slider;
    public Image fill;
    public Text Leveltext;

    public void SetnextLevel(int nextlevelxp)
    {
        slider.maxValue = nextlevelxp;
        slider.value = 0;

        
    }

    public void setxp(int xp)
    {
        slider.value = xp;


    }
    
    public void SetLevel(string level)
    {
        Leveltext.text = "LEVEL: " + level; 
    }
}
