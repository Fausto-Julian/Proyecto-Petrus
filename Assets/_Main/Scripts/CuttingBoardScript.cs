using System.Collections.Generic;
using UnityEngine;

public class CuttingBoardScript : MonoBehaviour, IInteractable
{
    [SerializeField] private ParticleSystem poofParticle;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip chopSound;

    //Hice esta variable booleana para que el audio no se reproduzca en cada frame en el que se interactua
    private bool _audioPlayOnce;
    private List<ICuttable> objects = new List<ICuttable>();
    [HideInInspector] public float timer => _timer;
    private float _timer;

    private void OnCollisionEnter(Collision collision)
    {
        var obj = collision.gameObject.GetComponent<ICuttable>();

        if (obj != null)
        {
            objects.Add(obj);
            //Se hace true cada vez que un objeto entra en la tabla
            _audioPlayOnce = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        var obj = other.gameObject.GetComponent<ICuttable>();

        if (obj != null)
        {
            if (objects.Contains(obj))
            {
                objects.Remove(obj);
                _timer = 0;
            }
        }
    }

    public void Interact()
    {
        if(objects.Count > 0)
        {
            HudManager.Instance.ActiveImageRadial(_timer, 2f);
            
            if(_timer > 0f && _audioPlayOnce)
            {
                audioSource.PlayOneShot(chopSound);
                //y se hace false cuando se reproduce
                _audioPlayOnce = false;
            }
             _timer += Time.deltaTime;
            if(_timer > 2f)
            {
                poofParticle.Play();

                objects[0].Cutting();
                objects.RemoveAt(0);
                _timer = 0f;
                _audioPlayOnce = true;
            }
        }
    }
}
