using System.Collections.Generic;
using UnityEngine;

public class CuttingBoardScript : MonoBehaviour, IInteractable
{
    private List<ICuttable> objects = new List<ICuttable>();
    
    [HideInInspector] public float timer => _timer;
    private float _timer;

    private void OnCollisionEnter(Collision collision)
    {
        var obj = collision.gameObject.GetComponent<ICuttable>();

        if (obj != null)
        {
            objects.Add(obj);
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
            _timer += Time.deltaTime;
            if(_timer > 2f)
            {
                objects[0].Cutting();
                objects.RemoveAt(0);
                _timer = 0f;
            }
        }
    }
}
