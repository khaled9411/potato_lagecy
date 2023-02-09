using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingBetweenTwoObjects : MonoBehaviour
{
    public Transform[] targets;
    int index = 0;
    public float speed;
    [HideInInspector] public  float currentSpeed;
    public bool partical = false;
    public float[] angles;
    public Vector3[] particalAngle;

    

    // Start is called before the first frame update
    void Start()
    {
        
        targets = new Transform[transform.parent.childCount - 1];
        for (int i = 0 ; i < transform.parent.childCount-1 ; i++)
        {
            targets[i]= transform.parent.GetChild(i+1);
        }
        currentSpeed = speed;
    }

    // Update is called once per frame
   void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, targets[index].position, currentSpeed*Time.deltaTime);
        if (Vector3.Distance(transform.position, targets[index].position) <= .2f)
        {
            index = (index + 1) % targets.Length;
            if (partical)
            {

                transform.GetChild(1).rotation = Quaternion.Euler(particalAngle[index]);
                
            }
        }
        if (partical)
            transform.rotation =Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(angles[index], transform.eulerAngles.y, transform.eulerAngles.z), 30*Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("enter");
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("exit");
        if (collision.gameObject.CompareTag("Player"))
        {
            if(!collision.gameObject.GetComponent<feat>().isHide)
                collision.transform.SetParent(null);
        }
    }

    
}
