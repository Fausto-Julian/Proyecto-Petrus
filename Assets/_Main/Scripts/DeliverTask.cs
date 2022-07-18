using UnityEngine;

public class DeliverTask : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Plate"))
        {
            var plate = other.gameObject.GetComponent<PlateController>();
            if (plate != null)
            {
                plate.RemoveObjectsInFloor();
                GameManager.Instance.DeliverTask(other.gameObject);
            }
        }
    }
}