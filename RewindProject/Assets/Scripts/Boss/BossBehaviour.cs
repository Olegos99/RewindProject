using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    [Range(0.5f,3f)]
    public float TimeToCheck = 2f;

    [Range(1f, 10f)]
    public float AcseptibleDistance = 3f;

    //public List<bool> Results;

    RewindCloneCreation RewindCloneCreation;
    PlayerManager PlayerManager;

    Transform PlayerTransform;
    Transform CloneTransform;

    public float DistanseBetwenPlayerAndClone = 0;

    Animator m_Animator;

    bool IsSeaking = false;
    bool BossCheckingPlayerCoorutineIsRunning = false;

    public float TimeSeen = 0;

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

        AudioManager.instanse.Play("BossIsWatching");

        // Results.Clear();

        while (time > 0)
        {
            if(DistanseBetwenPlayerAndClone > AcseptibleDistance || DistanseBetwenPlayerAndClone < 0)
            {
               // Results.Add(false);
            }
            else
            {
                TimeSeen += Time.deltaTime;
                //Results.Add(true);
            }
            yield return new WaitForSeconds(Time.deltaTime);
            time -= Time.deltaTime;
        }

        if(TimeSeen/TimeToCheck >= 0.5f)
        {
            m_Animator.SetTrigger("CloseEye");
        }
        else
        {
            m_Animator.SetTrigger("AttackPlayer");
            PlayerManager.instance.DeadFromBoss = true;
        }
        TimeSeen = 0;

        IsSeaking = false;
        BossCheckingPlayerCoorutineIsRunning = false;
    }

}
