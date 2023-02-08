using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;
using UnityEngine;

public class healthe : MonoBehaviour
{
    public int Healthe;
    public bool canDamage = true;
    public checkpointManager checkpointManager;
    public soundmanager soundmanager;
    public AudioClip die;

    private void Start()
    {
        soundmanager = FindObjectOfType<soundmanager>();
        canDamage = true;
    }
    public void Damage(int amontOfDamage)
    {
        if (canDamage)
        {
            Healthe -= amontOfDamage;
            checkpointManager.load(transform);
            soundmanager.playSound(die);
        }

        if(Healthe <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

 
}
