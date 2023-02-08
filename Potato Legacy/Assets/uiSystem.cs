using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiSystem : MonoBehaviour
{
    public Slider slider;
    public GameObject panel;
    public Collectable collectable;
    public Text health;
    public healthe healthe;
    bool candisable = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = collectable.amont;
        health.text = "x"+healthe.Healthe.ToString();
    }

    public void showlosepanel()
    {
        panel.SetActive(true);
        candisable = true;
    }
    void disablelosepanel()
    {
        panel.SetActive(false);
        candisable = false;
    }

}
