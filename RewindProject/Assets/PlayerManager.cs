using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    GameObject Player;
    CharacterController cc;
    public Vector3 StartingPosition;
    RecordPlayerPositions RecordPlayerPositions;
    public RewindCloneCreation RewindCloneCreation;
    public bool Dead = false;

    public static PlayerManager instance;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Player = this.gameObject;
        cc = Player.GetComponent<CharacterController>();
        StartingPosition = Player.transform.position;
        RecordPlayerPositions = GetComponent<RecordPlayerPositions>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Dead == true)
        {
            ResetPlayerToStart();
        }
    }

    private void ResetPlayerToStart()
    {
        Debug.Log("Reseting player");
        cc.enabled = false;
        Player.transform.position = StartingPosition;
        cc.enabled = true;
        //Player.transform.position = new Vector3(StartingPosition.x, StartingPosition.y,0);
        RecordPlayerPositions.ResetRecording();
        RewindCloneCreation.DestroyClone();
        Dead = false;
    }
}
