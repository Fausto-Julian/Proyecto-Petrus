using TMPro;
using UnityEngine;

public class MoneyHud : MonoBehaviour
{

    private TextMeshProUGUI _text;

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _text.text = $"{GameManager.Instance.GetMoneyDaily()}";
    }
}