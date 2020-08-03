using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindCloneManager : MonoBehaviour
{
    #region
    public static RewindCloneManager instance;
    private void Awake()
    {
        instance = this;
    }



    #endregion

    public GameObject RewindClone;
}
