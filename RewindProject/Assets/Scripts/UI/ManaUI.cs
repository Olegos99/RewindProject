using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaUI : MonoBehaviour
{
    public Image Background;
    public Image Forground;

    private float num;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetManaUIConterClocwise(float MaxMana, float CurrentMana)
    {
        float vOut1 = (float)CurrentMana;
        float vOut2 = (float)MaxMana;
        num = (vOut1 / vOut2);
        Forground.fillAmount = (num);
    }
    public void SetManaUIClocwise(float MaxMana, float CurrentMana)
    {
        float vOut1 = (float)CurrentMana;
        float vOut2 = (float)MaxMana;
        num = (vOut1 / vOut2);
        Forground.fillAmount = (1 - num);
    }
}
