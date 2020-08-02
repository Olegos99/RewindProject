using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordPlayerPositions : MonoBehaviour
{    
    public int RecordFrames = 300;
    public int CurrentRecordedFrames = 0;

    public List<Vector3> m_PlayerPositions;



    private void Start()
    {

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (CurrentRecordedFrames < RecordFrames)
        {
            m_PlayerPositions.Add(this.transform.position); 
        }
        else
        {
            m_PlayerPositions.RemoveAt(0);
            m_PlayerPositions.TrimExcess();
            m_PlayerPositions.Add(this.transform.position);
        }
        CurrentRecordedFrames = m_PlayerPositions.Count;
    }
}
