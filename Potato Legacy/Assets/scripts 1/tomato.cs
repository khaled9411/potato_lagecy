using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tomato : MonoBehaviour
{
    public Transform[] targets;
    int index = 0;
    float now = 0;
    public float speed;
    public float jumpforce = 0;
    [HideInInspector] public float currentSpeed;
    private Rigidbody Rigidbody;
    public int health = 3;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        targets = new Transform[transform.parent.childCount - 1];
        for (int i = 0; i < transform.parent.childCount - 1; i++)
        {
            targets[i] = transform.parent.GetChild(i + 1);
        }
        currentSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody.velocity = new Vector3(0, Rigidbody.velocity.y, transform.position.normalized.z - targets[index].position.normalized.z>0?-1*speed:1*speed);  
        if (Vector3.Distance(transform.position, targets[index].position) <= 2)
        {
            index = (index + 1) % targets.Length;
        }
        if (Time.time - now >= Random.Range(4, 10))
        {
            now = Time.time;
            Rigidbody.AddForce(0, jumpforce, 0);
        }
    }
}
