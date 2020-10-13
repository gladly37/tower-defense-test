using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sliderScript : MonoBehaviour
{
    Slider slider;
    public bloonSpawner bloonSpawner;
    public textHPUpdate textHP;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHpButton()
    {
        bloonSpawner.healthOfBloon = (int)slider.value;
        textHP.HP = (int)slider.value;
    }
}
