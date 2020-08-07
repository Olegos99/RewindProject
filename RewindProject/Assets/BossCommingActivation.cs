using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCommingActivation : MonoBehaviour
{
    public static BossCommingActivation instance;

    public bool PlayerCurrentlyInZone = false;
    public GameObject Boss;

    bool WasActivatedOnce = false;
    private void Awake()
    {
        instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {
            if (other.name == "Player" && !WasActivatedOnce)
            {
                WasActivatedOnce = true;
                Boss.GetComponent<Animator>().SetTrigger("Lvl1activation01");
            }
    }

    public void Reset()
    {
        WasActivatedOnce = false;
    }
}
