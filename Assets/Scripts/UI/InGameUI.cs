using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    //HP and MP bars controller script

    //Check values persistence, hp/mp

    //TO DO: - skill bar / attach values to sliders 
    // inventory and items
    //save system
    //map level


    public Slider sliderHp; //HP bar assigned to this field
    public Slider sliderMp; //sugar bar assigned to this field


    //Prepare the maximum value for the slider component
    public void SetMaxHealth(int health)
    {
        sliderHp.maxValue = health;
        sliderHp.value = health;
    }

    //Prepare the maximum value for the slider component
    public void SetMaxMp(int mana)
    {
        sliderMp.maxValue = mana;
        sliderMp.value = mana;
    }

    //Prepare the "filling" value for the slider component
    public void SetHealth(int health)
    {
        sliderHp.value = health;
    }

    //Prepare the "filling" value for the slider component
    public void SetMp(int mana)
    {
        sliderMp.value = mana;
    }
}
