using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grill_Script : MonoBehaviour
{
    private GameObject contactGameobject;
    private Transform contactPosition;
    [SerializeField] private GameObject coockedMeat;

    private float coockingTimer;
    private bool isOnGrill;
    //private List cookingObjects = new List<GameObject>();

    void Start()
    {
        coockingTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnGrill)
        {
            coockingTimer += Time.deltaTime;
        }
        else coockingTimer = 0f;
        if(coockingTimer >= 5f)
        {
            contactGameobject.SetActive(false);
            Instantiate(coockedMeat, contactPosition.position, contactGameobject.transform.rotation);
            coockingTimer = 0f;
        }

        Debug.Log(coockingTimer);
    }

    private void OnCollisionEnter(Collision collision)
    {
        contactGameobject = collision.gameObject;
        contactPosition = collision.transform;
    }
    private void OnCollisionStay(Collision collision)
    {
        isOnGrill = true;
        
    }

    private void OnCollisionExit(Collision collision)
    {
        isOnGrill = false;
    }
}
