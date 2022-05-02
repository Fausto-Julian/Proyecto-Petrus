using UnityEngine;

public class CuttingBoardScript : MonoBehaviour
{
    private GameObject _contactGameObject;
    private Transform _contactPosition;
    [SerializeField] private GameObject halfApple;
    private float _timer;

    private void Update()
    {
        if(_contactGameObject != null)
        {
            if (_contactGameObject.CompareTag("Object"))
            {
                if (Input.GetKey(KeyCode.Mouse1))
                {
                    _timer += Time.deltaTime;
                    if(_timer > 1f)
                    {
                        _contactGameObject.SetActive(false);
                        Instantiate(halfApple, _contactPosition.position, _contactGameObject.transform.rotation);
                        _timer = 0f;
                    }
                }
                else _timer = 0f;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        _contactGameObject = collision.gameObject;
        _contactPosition = collision.transform;
    }
}
