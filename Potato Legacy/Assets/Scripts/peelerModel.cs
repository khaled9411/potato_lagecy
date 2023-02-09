using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peelerModel : MonoBehaviour
{
    Rigidbody rb;
    peeler peeler;
    [HideInInspector]
    public Transform dropPoint;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        peeler = GetComponentInParent<peeler>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground1") || collision.gameObject.CompareTag("carrot"))
        {
            StartCoroutine(ResetPeeler());
        }
    }

    public IEnumerator ResetPeeler()
    {
        yield return new WaitForSeconds(2);

        peeler.distans = Vector3.Distance(transform.position, dropPoint.position);
        rb.isKinematic = true;
    }
}
