using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    [Range(0.5f,3f)]
    public float TimeToCheck = 2f;

    [Range(1f, 10f)]
    public float AcseptibleDistance = 3f;

    public List<bool> Results;

    RewindCloneCreation RewindCloneCreation;
    PlayerManager PlayerManager;

    Transform PlayerTransform;
    Transform CloneTransform;

    public float DistanseBetwenPlayerAndClone = 0;

    Animator m_Animator;

    bool IsSeaking = false;
    bool BossCheckingPlayerCoorutineIsRunning = false;

    private void Start()
    {
      //  PlayerTransform = PlayerManager.instance.PlayerTransform;
        m_Animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (RewindCloneCreation.instance.clone)
        {
            DistanseBetwenPlayerAndClone = Vector3.Distance(PlayerManager.instance.PlayerTransform.position, RewindCloneCreation.instance.clone.transform.position);
        }
        else
        {
            DistanseBetwenPlayerAndClone = -1;
        }

        if (IsSeaking && !BossCheckingPlayerCoorutineIsRunning)
        {
            StartCoroutine("BossCheckingPlayer");
        }
        if(!IsSeaking && BossCheckingPlayerCoorutineIsRunning)
        {
            StopAllCoroutines();
        }
    }


    void SetSeakingOn()
    {
        IsSeaking = true;
    }

    IEnumerator BossCheckingPlayer()
    {
        BossCheckingPlayerCoorutineIsRunning = true;

        float time = TimeToCheck;

        Results.Clear();

        while(time > 0)
        {
            if(DistanseBetwenPlayerAndClone > AcseptibleDistance || DistanseBetwenPlayerAndClone < 0)
            {
                Results.Add(false);
            }
            else
            {
                Results.Add(true);
            }
            yield return new WaitForSeconds(Time.deltaTime);
            time -= Time.deltaTime;
        }


        //function to check recults and acordingly set right animation
        m_Animator.SetTrigger("CloseEye");

        //m_Animator.SetTrigger("AttackPlayer");

        //        Results.Clear();

        IsSeaking = false;
        BossCheckingPlayerCoorutineIsRunning = false;
    }
}
