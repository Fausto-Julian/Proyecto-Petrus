using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Object"))
        {
            collision.transform.SetParent(transform);
        }
    }
    
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Object"))
        {
            collision.transform.SetParent(null);
        }
    }
}
