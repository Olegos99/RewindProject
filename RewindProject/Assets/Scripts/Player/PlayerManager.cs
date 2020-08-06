using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private GameObject Player;
    public Transform PlayerTransform;
    public Transform CameraTargetTransform;
    public Transform SecondCameraTargetTransform;
    CharacterController cc;
    public Vector3 StartingPosition;
    RecordPlayerPositions RecordPlayerPositions;
    RewindCloneCreation RewindCloneCreation;

    ParticleSystemController ParticleSystemController;

    public bool DeadFromSpikes = false;
    public bool DeadFromBoss = false;

    public bool DeadFromSpikesCoorutineIsRuning = false;
    public bool DeadFromBossCoorutineIsRuning = false;

    public float TimeDyingFromBoss =5f;
    public float TimeDyingFromSpikes = 1.5f;



    public static PlayerManager instance;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Player = this.gameObject;
        PlayerTransform = Player.transform;
        cc = Player.GetComponent<CharacterController>();
        StartingPosition = Player.transform.position;
        RewindCloneCreation = RewindCloneCreation.instance;
        RecordPlayerPositions = GetComponent<RecordPlayerPositions>();
        ParticleSystemController = GetComponentInChildren<ParticleSystemController>();
    }
    // Update is called once per frame
    void Update()
    {
        if(DeadFromSpikes == true && !DeadFromSpikesCoorutineIsRuning)
        {
            StartCoroutine("PlayerDyingFromSpikes");
        }
        if (DeadFromBoss == true && !DeadFromBossCoorutineIsRuning)
        {
            StartCoroutine("PlayerDyingFromBoss");
        }
    }

    IEnumerator PlayerDyingFromSpikes()
    {
        DeadFromSpikesCoorutineIsRuning = true;

        float time = TimeDyingFromSpikes;

        GetComponent<MovementControl>().MovementEnabled = false;

        RewindCloneCreation.instance.DestroyClone();
        RewindCloneCreation.instance.OnDeath();
        Player.GetComponent<MeshRenderer>().enabled = false;
        AudioManager.instanse.StopAllSounds();
        AudioManager.instanse.Play("Death");
        ParticleSystemController.ActivateParticleSystem(0, TimeDyingFromSpikes);

        yield return new WaitForSeconds(time);
        //set active death particles
        //while (time > 0)
        //{        
        //    yield return new WaitForSeconds(Time.deltaTime);
        //    time -= Time.deltaTime;
        //}
        GetComponent<MovementControl>().MovementEnabled = true;
        ResetPlayerToStart();
        DeadFromSpikesCoorutineIsRuning = false;
    }

    IEnumerator PlayerDyingFromBoss()
    {
        DeadFromBossCoorutineIsRuning = true;

        float time = TimeDyingFromBoss;

        CameraMovment.instance.ResetCameraTargetPositionToDeathView();

        GetComponent<MovementControl>().MovementEnabled = false;

        yield return new WaitForSeconds(time);

        RewindCloneCreation.instance.DestroyClone();
        RewindCloneCreation.instance.OnDeath();
        Player.GetComponent<MeshRenderer>().enabled = false;
        ParticleSystemController.ActivateParticleSystem(0, time);
        AudioManager.instanse.StopAllSounds();
        AudioManager.instanse.Play("Death");
        AudioManager.instanse.Play("Denied");

        yield return new WaitForSeconds(time);

        GetComponent<MovementControl>().MovementEnabled = true;
        ResetPlayerToStart();
        DeadFromBossCoorutineIsRuning = false;
    }

    private void ResetPlayerToStart()
    {
        Debug.Log("Reseting player");
        cc.enabled = false;
        Player.transform.position = StartingPosition;
        cc.enabled = true;
        //Player.transform.position = new Vector3(StartingPosition.x, StartingPosition.y,0);
        if (SceeneManager.instance.CurrentSceneNumber == 1)
        {
            BossCommingActivation.instance.Reset();
            Lvl1Activation.instance.Reset();
        }
        CameraMovment.instance.ResetCameraTargetPositionToNormalView();
        RecordPlayerPositions.ResetRecording();
        RewindCloneCreation.DestroyClone();
        Player.GetComponent<MeshRenderer>().enabled = true;
        DeadFromSpikes = false;
        DeadFromBoss = false;
    }
}
