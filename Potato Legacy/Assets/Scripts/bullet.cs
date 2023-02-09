using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;
    Rigidbody rb;
    public soundmanager soundmanager;
    public AudioClip die;
    public GameObject particale;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        soundmanager = FindObjectOfType<soundmanager>();
        rb.velocity = transform.forward * speed;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponentInParent<healthe>().Damage(1); 
        }
        if(other.gameObject.tag == "tomato")
        {
            other.gameObject.GetComponent<tomato>().health--;
           if(other.gameObject.GetComponent<tomato>().health<= 0)
            {
                Instantiate(particale, other.transform.position, Quaternion.identity);
                Destroy(other.gameObject);
                soundmanager.playSound(die);
            }
        }
        
        Destroy(gameObject);
    }
}
