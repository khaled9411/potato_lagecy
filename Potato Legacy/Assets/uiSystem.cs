using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class uiSystem : MonoBehaviour
{
    public Slider slider;
    public GameObject panel;
    public Collectable collectable;
    public Text health;
    public healthe healthe;
    bool win = false;
    public string[] parapmetares;
    Animator Animator;
    public static uiSystem u;
    

    void Start()
    {
        Animator = panel.GetComponentInChildren<Animator>();
        u = this;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = collectable.amont;
        health.text = "x"+healthe.Healthe.ToString();
        if (panel.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            panel.SetActive(false);
            if (win)
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    public void showlevelpanel(int index)
    {
        panel.SetActive(true);
        if (index != 0)
        {
            panel.transform.GetChild(1).gameObject.SetActive(true);
            for (int i = 1; i <= index; i++) 
            {
                Animator.SetBool(parapmetares[i-1], true);
                panel.transform.GetChild(i + 1).gameObject.SetActive(true);
                
            }
        }
        if (index == 3)
        {
            win = true;
            Debug.Log("win");
        }
    }
  


}
