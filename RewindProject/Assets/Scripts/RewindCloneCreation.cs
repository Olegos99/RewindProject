﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RewindCloneCreation : MonoBehaviour
{
    public GameObject RewindClone;
    public GameObject Player;

    public List<Vector2> PlayerPositions;
    public List<bool> PlayerEpressing;

    GameObject clone;

    [Range(1,5)]
    public float RewindClooneCooldown = 1f;

    private bool RewindClooneCooldownCoorutineIsRunning = false;

    private float time;

    public bool CloneIsPressingE;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && clone == null && !RewindClooneCooldownCoorutineIsRunning)
        {
            PlayerPositions = new List<Vector2>(Player.GetComponentInChildren<RecordPlayerPositions>().m_PlayerPositions);
            PlayerEpressing = new List<bool>(Player.GetComponentInChildren<RecordPlayerPositions>().m_PlayerPressE);
            
            clone = Instantiate(RewindClone, Player.transform.position, Quaternion.identity);
            Debug.Log("R was pressed");
        }
        else if(Input.GetKeyDown(KeyCode.R) && clone != null)
        {
            Destroy(clone);
            StartCoroutine("RewindClooneCooldownCoorutine");
            PlayerPositions.Clear();
            PlayerEpressing.Clear();
            CloneIsPressingE = false;
        }
    }

    private void FixedUpdate()
    {
        if(clone)
        {
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
                StartCoroutine("RewindClooneCooldownCoorutine");
                Destroy(clone);
                PlayerEpressing.Clear();
                PlayerPositions.Clear();
            }
        }
    }

    IEnumerator RewindClooneCooldownCoorutine()
    {
        RewindClooneCooldownCoorutineIsRunning = true;
        time = RewindClooneCooldown;
        while (time > 0)
        {
            time -= Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        time = 0;
        RewindClooneCooldownCoorutineIsRunning = false;
    }
}
