using UnityEngine;
using UnityEngine.AI;

public class GarbageController : MonoBehaviour
{
    [SerializeField] private Transform startPosition;
    [SerializeField] private GarbageFloor garbageFloor;
    
    private NavMeshAgent _navMeshAgent;
    
    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        _navMeshAgent.destination = garbageFloor.ObjectDrops.Count > 0 ? garbageFloor.ObjectDrops[0].transform.position : startPosition.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (garbageFloor.ObjectDrops.Count > 0)
        {
            if (other.gameObject == garbageFloor.ObjectDrops[0].gameObject)
            {
                garbageFloor.ObjectDrops.Remove(garbageFloor.ObjectDrops[0]);
                Destroy(other.gameObject);
            }  
        }
    }
}
