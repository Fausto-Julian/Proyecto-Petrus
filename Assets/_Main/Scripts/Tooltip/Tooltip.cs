using UnityEngine;
using UnityEngine.UI;
using TMPro;

[ExecuteInEditMode()]
public class Tooltip : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI headerField;
    [SerializeField] private TextMeshProUGUI contentField;
    [SerializeField] private LayoutElement _layoutElement;

    private RectTransform _rectTransform;
    private int _characterLimit = 40;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (Application.isEditor)
        {
            int headerLength = headerField.text.Length;
            int contentLength = contentField.text.Length;

            _layoutElement.enabled = (headerLength > _characterLimit || contentLength > _characterLimit) ? true : false;
        }

        //Vector2 mousePosition = Input.mousePosition;

        //transform.position = mousePosition;
    }


    public void SetText(string content, string header = "")
    {
        if (string.IsNullOrEmpty(header))
        {
            headerField.gameObject.SetActive(false);
        }
        else
        {
            headerField.gameObject.SetActive(true);
            headerField.text = header;
        }
        contentField.text = content;

        int headerLength = headerField.text.Length;
        int contentLength = contentField.text.Length;

        _layoutElement.enabled = (headerLength > _characterLimit || contentLength > _characterLimit) ? true : false;
    }
}
