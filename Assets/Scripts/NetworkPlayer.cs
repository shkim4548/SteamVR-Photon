using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;
using Photon.Realtime;

public class NetworkPlayer : MonoBehaviour
{
    public Transform head;
    public Transform leftHand;
    public Transform rightHand;
    private PhotonView photonView;

    private Transform headPos;
    private Transform leftHandPos;
    private Transform rightHandPos;

    void Start()
    {
        photonView = GetComponent<PhotonView>();
        GameObject player = GameObject.FindWithTag("Steam VR Player");
        headPos = player.transform.Find("SteamVRObjects/VRCamera");
        leftHandPos = player.transform.Find("SteamVRObjects/LeftHand");
        rightHandPos = player.transform.Find("SteamVRObjects/RightHand");
    }

    void Update()
    {
        if(photonView.IsMine)
        {
            //head.gameObject.SetActive(false);
            //leftHand.gameObject.SetActive(false);
            //rightHand.gameObject.SetActive(false);

            MapPosition(head, headPos);
            MapPosition(leftHand, leftHandPos);
            MapPosition(rightHand, rightHandPos);
        }
    }

    void MapPosition(Transform target, Transform partTransform)
    {
        target.position = partTransform.position;
        target.rotation = partTransform.rotation;
    }
}
