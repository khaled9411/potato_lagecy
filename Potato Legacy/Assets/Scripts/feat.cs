using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feat : MonoBehaviour
{
    Collectable Collectable;
    healthe healthe;
    Rigidbody rb;
    movement movement;
    public soundmanager soundmanager;

    public float timeToDestroyShield;

    public float fireCost = 5;
    public float sheildCost;
    public float hideCost;

    float realSpeed;
    float realJumpForce;
    float realRotationSpeed;

    public Transform firePointZ;
    public Transform firePointX;
    public GameObject bulletPrefabe;
    public GameObject sheildprefabe;
    GameObject currentshield;

    public bool cansheild;
    public bool canfire;
    public bool canhide;
    bool isGrounded;

    public MeshCollider MeshCollider;
    Vector3 currntPos;
    Vector3 HidePos;
    public AudioClip fire;

    [HideInInspector]
    public bool isHide;

    // Start is called before the first frame update
    void Start()
    {
        Collectable = GetComponent<Collectable>();
        healthe = GetComponent<healthe>();
        rb = GetComponent<Rigidbody>();
        movement = GetComponent<movement>();

        ; soundmanager = FindObjectOfType<soundmanager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            shoot(firePointZ);

        }else if (Input.GetKeyDown(KeyCode.X))
        {
            shoot(firePointX);
        }else if (Input.GetKeyDown(KeyCode.C))
        {
           
           StartCoroutine(sheild());
        }else if (Input.GetKeyDown(KeyCode.V))
        {
            isGrounded = movement.IsGrounded();
            realSpeed = movement.speed;
            realRotationSpeed = movement.rotationSpeed;
            realJumpForce = movement.JumpForce;
            currntPos = transform.position + new Vector3(0, 1f, 0);
            HidePos = transform.position - new Vector3(0, 0.5f, 0);


        }else if (Input.GetKey(KeyCode.V))
        {
            if(canhide)
                Hide();

        }else if (Input.GetKeyUp(KeyCode.V))
        {
            StopHide();
        }

    }
    
    void shoot(Transform firePoint)
    {
        if(Collectable.amont >= fireCost & canfire)
        {
            soundmanager.playSound(fire);
            Collectable.amont -= fireCost;
            GameObject obj = Instantiate(bulletPrefabe, firePoint.position, firePoint.rotation);
            obj.transform.localScale = Vector3.one *.5f;

        }

    }

    IEnumerator sheild()
    {
        if(Collectable.amont >= sheildCost & cansheild)
        {
            healthe.canDamage = false;
            currentshield = Instantiate(sheildprefabe, transform.position, Quaternion.identity,transform.GetChild(0));
            Collectable.amont -= sheildCost;
            yield return new WaitForSeconds(timeToDestroyShield);
            healthe.canDamage=true;
            currentshield.GetComponent<Animator>().SetTrigger("end");
            yield return new WaitForSeconds(.5f);
            Destroy(currentshield);

        }
    }

    IEnumerator ShieldEfe()
    {
        currentshield.transform.localScale = currentshield.transform.localScale + Vector3.one * Time.deltaTime * 30;
        yield return new WaitForSeconds(timeToDestroyShield);

    }

    void Hide()
    {

        if(Collectable.amont >= hideCost && isGrounded)
        {
            isHide= true;
            Collectable.amont -= hideCost * Time.deltaTime;
            MeshCollider.enabled = false;
            rb.isKinematic = true;
            rb.useGravity = false;
            movement.speed = 0;
            movement.rotationSpeed = 0;
            movement.JumpForce = 0;
            transform.position = Vector3.MoveTowards(transform.position, HidePos, Time.deltaTime);
        }
        else
        {
            StopHide();
        }
        

    }

    void StopHide()
    {

        isHide = false;
        transform.position = Vector3.MoveTowards(transform.position, currntPos, Time.deltaTime);

        
        
        MeshCollider.enabled = true;
        rb.isKinematic = false;
        rb.useGravity = true;
        movement.speed = realSpeed;
        movement.rotationSpeed = realRotationSpeed;
        movement.JumpForce = realJumpForce;

        

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "canfire")
        {
            canfire = true;
            uiSystem.u.showlevelpanel(0);
        }
        if (other.gameObject.tag == "canhide")
        {
            canhide = true;
            uiSystem.u.showlevelpanel(1);
        }
        if(other.gameObject.tag == "cansheild")
        {
            cansheild = true;
            uiSystem.u.showlevelpanel(2);
        }
    }

}
