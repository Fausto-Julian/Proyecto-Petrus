using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GordonController : MonoBehaviour
{
    [SerializeField] private float minTimerHide;
    [SerializeField] private float maxTimerHide;
    [SerializeField] private float minTimerShow;
    [SerializeField] private float maxTimerShow;
    [SerializeField] private Transform hideTranform;
    [SerializeField] private Transform showTranform;

    private float currentTimeHide;
    private float currentTimeShow;

    private bool isShow;

    private void Awake()
    {
        currentTimeHide = Random.Range(minTimerHide, maxTimerHide);
        currentTimeShow = Random.Range(minTimerShow, maxTimerShow);

        isShow = false;

        transform.position = hideTranform.position;
    }

    private void Update()
    {
        if (!isShow)
        {
            currentTimeHide -= Time.deltaTime;

            if (currentTimeHide <= 0)
            {
                currentTimeHide = Random.Range(minTimerHide, maxTimerHide);
                isShow = true;
                transform.position = showTranform.position;
            }
        }

        if (isShow)
        {
            currentTimeShow -= Time.deltaTime;

            if (currentTimeShow <= 0)
            {
                currentTimeShow = Random.Range(minTimerShow, maxTimerShow);

                isShow = false;
                transform.position = hideTranform.position;
            }
        }
    }
}
