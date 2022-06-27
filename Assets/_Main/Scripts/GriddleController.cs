using UnityEngine;

public class GriddleController : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        var meatController = other.gameObject.GetComponent<MeatController>();
        if (meatController != null)
        {
            meatController.OnCooking();
            _audioSource.Play();
        }

        var breadController = other.gameObject.GetComponent<BreadController>();
        if (breadController != null)
        {
            breadController.OnCooking();
            _audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var meatController = other.gameObject.GetComponent<MeatController>();
        if (meatController != null)
        {
            meatController.OffCooking();
            _audioSource.Stop();
        }

        var breadController = other.gameObject.GetComponent<BreadController>();
        if (breadController != null)
        {
            breadController.OffCooking();
            _audioSource.Stop();
        }
    }
}