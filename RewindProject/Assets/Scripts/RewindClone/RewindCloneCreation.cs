using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RewindCloneCreation : MonoBehaviour
{
    public GameObject RewindClone;
    public GameObject Player;

    public List<Vector2> PlayerPositions;
    public List<bool> PlayerEpressing;

    public ManaUI m_ManaUI;

    public GameObject clone;

    [Range(1,5)]
    public float RewindClooneCooldown = 1f;

    private bool RewindClooneCooldownCoorutineIsRunning = false;

    private float time;

    public bool CloneIsPressingE;

    private int RecordedFramesCount;


    public static RewindCloneCreation instance;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (MovementControl.instance.MovementEnabled)
        {
            if (Input.GetKeyDown(KeyCode.Q) && clone == null && !RewindClooneCooldownCoorutineIsRunning)
            {
                PlayerPositions = new List<Vector2>(Player.GetComponentInChildren<RecordPlayerPositions>().m_PlayerPositions);
                PlayerEpressing = new List<bool>(Player.GetComponentInChildren<RecordPlayerPositions>().m_PlayerPressE);

                RecordedFramesCount = PlayerPositions.Count;

                clone = Instantiate(RewindClone, Player.transform.position, Quaternion.identity);
                Debug.Log("R was pressed");
            }
            else if (Input.GetKeyDown(KeyCode.Q) && clone != null)
            {
                DestroyClone();
            }
        }
    }

    private void FixedUpdate()
    {
        if(clone)
        {
            if (!AudioManager.instanse.IsSoundIsPlayingNow("RewindInWorking"))
            {
                AudioManager.instanse.Play("RewindInWorking");
            }
            if (PlayerPositions.Count > 0)
            {
                clone.transform.position = PlayerPositions.Last();

                CloneIsPressingE = PlayerEpressing[PlayerEpressing.Count - 1];

                PlayerEpressing.RemoveAt(PlayerEpressing.Count -1);
               // PlayerEpressing.Remove(PlayerEpressing.l);
                PlayerPositions.Remove(PlayerPositions.Last());
            }
            else
            {
                DestroyClone();
            }
            m_ManaUI.SetManaUIConterClocwise(RecordedFramesCount, PlayerPositions.Count);
        }
    }

    public void DestroyClone()
    {
        AudioManager.instanse.Stop("RewindInWorking");
        AudioManager.instanse.Play("RewindEnds");
        Destroy(clone);
        StartCoroutine("RewindClooneCooldownCoorutine");
        PlayerPositions.Clear();
        PlayerEpressing.Clear();
        CloneIsPressingE = false;
    }

    public void OnDeath()
    {
        StopAllCoroutines();
        AudioManager.instanse.Stop("RewindInWorking");
        AudioManager.instanse.Stop("RewindEnds");
        AudioManager.instanse.Stop("RewindInColdown");
        m_ManaUI.SetManaUIClocwise(0, 1);
    }

    IEnumerator RewindClooneCooldownCoorutine()
    {
        RewindClooneCooldownCoorutineIsRunning = true;
        time = RewindClooneCooldown;
        AudioManager.instanse.Play("RewindInColdown");
        while (time > 0)
        {
            time -= Time.deltaTime;
            m_ManaUI.SetManaUIClocwise(RewindClooneCooldown, time);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        time = 0;
        AudioManager.instanse.Stop("RewindInColdown");
        AudioManager.instanse.Play("RewindReady");
        RewindClooneCooldownCoorutineIsRunning = false;
    }


}
