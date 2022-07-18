using UnityEngine;
using UnityEngine.AI;

public class GarbageController : MonoBehaviour
{
    [SerializeField] private Transform startPosition;
    [SerializeField] private GarbageFloor garbageFloor;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip soundClip;
    
    private NavMeshAgent _navMeshAgent;
    
    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (GameManager.Instance.GetProgressLevels().BasurinLevel > 1)
        {
            _navMeshAgent.destination = garbageFloor.ObjectDrops.Count > 0 ? garbageFloor.ObjectDrops[0].transform.position : startPosition.position;
        }

        _navMeshAgent.speed = GameManager.Instance.GetProgressLevels().BasurinLevel;
    }

    private void OnTriggerStay(Collider other)
    {
        if (garbageFloor.ObjectDrops.Count > 0)
        {
            for (var i = 0; i < garbageFloor.ObjectDrops.Count; i++)
            {
                if (other.gameObject == garbageFloor.ObjectDrops[i])
                {
                    garbageFloor.ObjectDrops.Remove(garbageFloor.ObjectDrops[i]);
                    source.PlayOneShot(soundClip);
                    Destroy(other.gameObject);
                }
            }
        }
    }
}
