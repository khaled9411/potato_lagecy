using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class carrot : MonoBehaviour
{

    public float speed;
    float currentSpeed;
    float now = 0;
    bool isWait;
    public bool willStop;
    private void Start()
    {
        currentSpeed = speed;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, currentSpeed * Time.deltaTime, 0));
        if (willStop)
        {
            if (Time.time - now >= Random.Range(7, 20) & !isWait)
            {
                now = Time.time;
                gameObject.GetComponent<movingBetweenTwoObjects>().currentSpeed = 0;
                currentSpeed = 0;
                isWait = true;
            }

            if (Time.time - now >= Random.Range(2, 7) & isWait)
            {
                now = Time.time;
                currentSpeed = speed;
                gameObject.GetComponent<movingBetweenTwoObjects>().currentSpeed = gameObject.GetComponent<movingBetweenTwoObjects>().speed;
                isWait = false;
            }
        }
    }
}
