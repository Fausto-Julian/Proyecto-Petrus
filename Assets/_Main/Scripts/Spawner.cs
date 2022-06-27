
using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private Transform spawnPosition;
    private AudioSource audioSource;

    private bool _delay;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Interact()
    {
        if (!_delay)
        {
            StartCoroutine(nameof(Instantiate));
            audioSource.Play();
        }
        
    }

    private IEnumerator Instantiate()
    {
        _delay = true;
        Instantiate(objectPrefab, spawnPosition.position, spawnPosition.rotation);
        yield return new WaitForSeconds(1f);
        _delay = false;
    }
}