using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peeler : MonoBehaviour
{
    Rigidbody rb;
    Transform dropPoint;
    Transform model;

    [HideInInspector]
    public float distans;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInChildren<Rigidbody>();
        rb.isKinematic = false;
        model = transform.GetChild(0);
        dropPoint = transform.GetChild(1);

        model.gameObject.GetComponent<peelerModel>().dropPoint = dropPoint;
        
    }

    // Update is called once per frame
    void Update()
    {
       float chengableDistans = Vector3.Distance(model.position, dropPoint.position);

        if (chengableDistans <= 0.5f)
        {
            rb.isKinematic = false;
        }
        if (rb.isKinematic)
        { 

            model.position = Vector3.Lerp(model.position, dropPoint.position, chengableDistans / (distans * 10));

        }
    }


}
