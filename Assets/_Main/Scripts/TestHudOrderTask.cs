using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TestHudOrderTask : MonoBehaviour
{
    public static TestHudOrderTask Instance;

    [SerializeField] private Image image;

    private bool activeImage;
    
    private void Awake()
    {
        if (TestHudOrderTask.Instance == null)
        {
            TestHudOrderTask.Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        image.gameObject.SetActive(false);
    }

    public void ActivateImageTask(Sprite sprite)
    {
        image.sprite = sprite;
        image.gameObject.SetActive(true);
        /*
        if (!activeImage)
        {
            image.sprite = sprite;
            StartCoroutine(nameof(Active));
        }*/
    }

    public void DeactivateImageTask()
    {
        image.gameObject.SetActive(false);
    }

    private IEnumerator Active()
    {
        image.gameObject.SetActive(true);
        activeImage = true;
        yield return new WaitForSeconds(2.5f);
        image.gameObject.SetActive(false);
        activeImage = false;
    }
}