using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public bool canUseFeat;

    public checkpointManager checkpointManager;
    public float amont;
    public soundmanager soundmanager;
    public AudioClip collect;
    public AudioClip chickpoint;
    // Start is called before the first frame update
    void Start()
    {
        soundmanager = FindObjectOfType<soundmanager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Water"))
        {
            amont = Mathf.Clamp(amont+10,0,100);
            other.gameObject.SetActive(false);
            soundmanager.playSound(collect);

        }

        if (other.gameObject.CompareTag("checkpoint"))
        {
            
            checkpointManager.save(other.transform);
            soundmanager.playSound(chickpoint);

        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "tomato" || collision.gameObject.tag == "carrot" || collision.gameObject.tag == "bullet")
        {
            gameObject.GetComponent<healthe>().Damage(1);
        }
    }
}
