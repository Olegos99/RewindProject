using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RewindCloneCreation : MonoBehaviour
{
    public GameObject RewindClone;
    public GameObject Player;

    public List<Vector3> PlayerPositions;

    GameObject clone;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && clone == null)
        {
            PlayerPositions = new List<Vector3>(Player.GetComponentInChildren<RecordPlayerPositions>().m_PlayerPositions);
            //PlayerPositions = Player.GetComponentInChildren<RecordPlayerPositions>().m_PlayerPositions;
            clone = Instantiate(RewindClone, Player.transform.position, Quaternion.identity);
            Debug.Log("R was pressed");
        }
        else if(Input.GetKeyDown(KeyCode.R) && clone != null)
        {
            Destroy(clone);
            PlayerPositions.Clear();
        }
    }

    private void FixedUpdate()
    {
        if(clone)
        {
            if (PlayerPositions.Count > 0)
            {
                clone.transform.position = PlayerPositions.Last();
                PlayerPositions.Remove(PlayerPositions.Last());
            }
            else
            {
                Destroy(clone);
                PlayerPositions.Clear();
            }
        }
    }
}
