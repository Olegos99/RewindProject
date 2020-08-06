using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemController : MonoBehaviour
{
    public GameObject[] ParticleSystemS;

    bool ActivateParticleSystemCoorutineIsRuning = false;

    public static ParticleSystemController instance;

    private void Awake()
    {
        instance = this;
    }
    public void ActivateParticleSystem(int i, float time)
    {
        if (!ActivateParticleSystemCoorutineIsRuning)
        {
            StartCoroutine(ActivateParticleSystemCoorutine(i, time));
        }
    }

    IEnumerator ActivateParticleSystemCoorutine(int i, float Time)
    {
        ActivateParticleSystemCoorutineIsRuning = true;

        float time = Time;

        ParticleSystemS[i].SetActive(true);
        //player partical system

        yield return new WaitForSeconds(time);

        ParticleSystemS[i].SetActive(false);

        ActivateParticleSystemCoorutineIsRuning = false;
    }
}
