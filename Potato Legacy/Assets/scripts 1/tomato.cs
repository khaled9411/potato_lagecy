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
    float random;

    // Start is called before the first frame update
    void Start()
    {
        random=Random.Range(4, 8);
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
        Rigidbody.velocity = new Vector3(0, Rigidbody.velocity.y, -(transform.position - targets[index].position).normalized.z *speed );  
        if (Vector3.Distance(transform.position, targets[index].position) <= 0.5f)
        {
            index = (index + 1);
            if (index == targets.Length) index = 0;

        }
        if (Time.time - now >= random)
        {
            random = Random.Range(4, 8);
            now = Time.time;
            Rigidbody.AddForce(0, jumpforce, 0);
        }
    }
}
