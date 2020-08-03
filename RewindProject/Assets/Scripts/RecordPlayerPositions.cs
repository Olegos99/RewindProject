using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordPlayerPositions : MonoBehaviour
{    
    public int RecordFrames = 300;
    public int CurrentRecordedFrames = 0;

    public List<Vector2> m_PlayerPositions;
    public List<bool> m_PlayerPressE;

    private bool IsPressed;
    //[SerializeField]
    //public class InfoPak
    //{
    //    public Vector3 Position { get; set; }
    //    public bool IsEwasPressed { get; set; }
    //}

    //public List<InfoPak> m_InfoPaks;

    private void Start()
    {

    }


    private void Update()
    {
        if(Input.GetKey(KeyCode.E))
        {
            IsPressed = true;
        }
        else
        {
            IsPressed = false;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (CurrentRecordedFrames < RecordFrames)
        {
            m_PlayerPositions.Add(this.transform.position);
            m_PlayerPressE.Add(IsPressed);

            //var m_InfoPak = new InfoPak();
            //m_InfoPak.IsEwasPressed = Input.GetKeyDown(KeyCode.E);
            //m_InfoPak.Position = this.transform.position;
            //m_InfoPaks.Add(m_InfoPak);
        }
        else
        {
            m_PlayerPositions.RemoveAt(0);
            m_PlayerPositions.TrimExcess();
            m_PlayerPositions.Add(this.transform.position);

            m_PlayerPressE.RemoveAt(0);
            m_PlayerPositions.TrimExcess();
            m_PlayerPressE.Add(IsPressed);

            //m_InfoPaks.RemoveAt(0);
            //m_InfoPaks.TrimExcess();
            //var m_InfoPak = new InfoPak();
            //m_InfoPak.IsEwasPressed = Input.GetKeyDown(KeyCode.E);
            //m_InfoPak.Position = this.transform.position;
            //m_InfoPaks.Add(m_InfoPak);

        }
        CurrentRecordedFrames = m_PlayerPositions.Count;
    }
}
