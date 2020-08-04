using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovment : MonoBehaviour
{
    Transform CameraTargetPosition;
    float DistanceToTarget;

    PlayerManager PlayerManager;
    void Start()
    {
        PlayerManager = PlayerManager.instance;
        CameraTargetPosition = PlayerManager.CameraTargetTransform;
    }

    // Update is called once per frame
    void Update()
    {
        DistanceToTarget = Vector3.Distance(transform.position, CameraTargetPosition.position);
        if (DistanceToTarget > 0.1f)
        {
            //transform.position = Vector3.Slerp(transform.position, CameraTargetPosition.position, Mathf.Clamp(DistanceToTarget, 0, 1) * Time.deltaTime);
            transform.position = Vector3.Slerp(transform.position, CameraTargetPosition.position,DistanceToTarget * Time.deltaTime);
        }
        else
        {
            //transform.position = new Vector3(CameraTargetPosition.position.x, CameraTargetPosition.position.y, CameraTargetPosition.position.z);
        }
    }
}
