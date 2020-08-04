using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTimeUI : MonoBehaviour
{
    public Image Background;
    public Image Forground;

    private float num;


    public void SetTimerUIClocwise(float MaxTime, float CurrentTime)
    {
        float vOut1 = (float)CurrentTime;
        float vOut2 = (float)MaxTime;
        num = (vOut1 / vOut2);
        Forground.fillAmount = (1 - num);
    }
}
