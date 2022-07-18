using System.Collections;
using UnityEngine;

public class ButtonBasurinDestruction : MonoBehaviour, IInteractable
{
    //El player interactua con el boton
    //Play a la particula de la explosion + sonido + etc
    //El viejo basurin es teleportado a su respawn
    //Hacer un coolDown de 5'

    [SerializeField] private GameObject basurinObj;
    [SerializeField] private Transform basurinSpawnPoint;
    [SerializeField] private ParticleSystem explotionParticle;
    [SerializeField] private AudioClip explotionAudio;

    private AudioSource audioSourceBasurin;
    private bool _delay;

    private void Awake()
    {
        audioSourceBasurin = basurinObj.GetComponent<AudioSource>();
    }

    public void Interact()
    {
        if (!_delay)
        {
            StartCoroutine(nameof(BasurinRestart));
        }
    }

    private IEnumerator BasurinRestart()
    {
        _delay = true;
        Transform oldBasurinTransform = basurinObj.transform;
        explotionParticle.transform.position = oldBasurinTransform.position;
        explotionParticle.Play();

        
        basurinObj.transform.position = basurinSpawnPoint.position;

        
        audioSourceBasurin.PlayOneShot(explotionAudio);

        yield return new WaitForSeconds(3f);
        _delay = false;
    }
}
