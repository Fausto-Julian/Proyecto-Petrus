using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateScript : MonoBehaviour
{
    private Rigidbody bodyContact;
    private Transform posContact;

    

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Object")
        {
            bodyContact = collision.rigidbody;
            posContact = collision.transform;

            bodyContact.isKinematic = false;
            
            collision.transform.SetParent(transform);

        }
    }

    
}
