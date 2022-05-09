
using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject objectPrefab;

    private bool _delay;
    
    public void Interact()
    {
        if (!_delay)
        {
            StartCoroutine(nameof(Instantiate));
        }
        
    }

    private IEnumerator Instantiate()
    {
        _delay = true;
        Instantiate(objectPrefab, transform);
        yield return new WaitForSeconds(1f);
        _delay = false;
    }
}