using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grill_Script : MonoBehaviour
{
    private GameObject contactGameobject;

    private float coockingTimer;
    //private List cookingObjects = new List<GameObject>();



    void Start()
    {
        coockingTimer = 0f;
    }
    void Update()
    {
        if (contactGameobject != null)
        {
            coockingTimer += Time.deltaTime;

            if (coockingTimer >= 5f)
            {
                coockingTimer = 0f;
                contactGameobject = null;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        contactGameobject = collision.gameObject;
    }

    private void OnCollisionExit(Collision collision)
    {
        coockingTimer = 0f;
        contactGameobject = null;
    }
}
