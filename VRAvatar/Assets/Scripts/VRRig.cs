using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//VRRig에 연결하기 위한 스크립트, steamVR이라면 Player prefab에 연결하기 위한 스크립트
[System.Serializable]
public class VRMap
{
    public Transform vrTarget;
    public Transform rigTarget;
    public Vector3 trackingPositionOffset;
    public Vector3 trackingRotationOffset;

    public void Map()
    {
        rigTarget.position = vrTarget.TransformPoint(trackingPositionOffset);
        rigTarget.rotation = vrTarget.rotation * Quaternion.Euler(trackingRotationOffset);
    }
}

public class VRRig : MonoBehaviour
{
    public VRMap head;
    public VRMap leftHand;
    public VRMap rightHand;

    public Transform headConstraint;
    public Vector3 headBodyOffset;

    void Start()
    {
        headBodyOffset = transform.position - headConstraint.position;
    }

    //나중에 연결해보고 수정해야함
    void FixedUpdate()
    {
        transform.position = headConstraint.position + headBodyOffset;
        transform.forward = Vector3.ProjectOnPlane(headConstraint.up, Vector3.up).normalized;
        head.Map();
        leftHand.Map();
        rightHand.Map();
    }
}
