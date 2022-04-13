using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingBoardScript : MonoBehaviour
{
    private GameObject contactGameobject;
    private Transform contactPosition;
    [SerializeField] private GameObject halfApple;
    private float timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(contactGameobject != null)
        {
            if (contactGameobject.CompareTag("Object"))
            {
                if (Input.GetKey(KeyCode.Mouse1))
                {
                    timer += Time.deltaTime;
                    if(timer > 1f)
                    {
                        contactGameobject.SetActive(false);
                        Instantiate(halfApple, contactPosition.position, contactGameobject.transform.rotation);
                        timer = 0f;
                    }
                }
                else timer = 0f;
            }
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        contactGameobject = collision.gameObject;
        contactPosition = collision.transform;
    }
}
