using UnityEngine;

public class GordonEyeTracker : MonoBehaviour
{
    [SerializeField] private Transform eyeBall;
    private GameObject player;

    private Vector3 playerDirection;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            transform.LookAt(player.transform.position);
        }
    }

    public void ResetGordonSight()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
}
