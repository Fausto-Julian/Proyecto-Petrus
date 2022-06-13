using UnityEngine;

public class GordonEyeTracker : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform eyeBall;
    [SerializeField] private Transform pupil;

    private Vector3 playerDirection;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //La pupila va a cambiar sus coordenadas al rededor del ojo, apuntando al player
        //
        //Vector3 playerDirection = (player.position - eyeBall.position).normalized;

        ////la direccion de la pupila = nuestro 0,0. + la direccion al player, que no salga de la esfera
        //pupil.position = (new Vector3(12, 12, 12) + eyeBall.position + playerDirection);\

        transform.LookAt(player);

    }

    private void OnDrawGizmos()
    {
        Debug.DrawLine(eyeBall.position, player.position, Color.yellow);
    }
}
