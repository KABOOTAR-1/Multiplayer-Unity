using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class tankbarel : MonoBehaviour
{
    [SerializeField] private string version = "0.1";
    public Transform tankbarrel;
    public float y=0,x=0;
    public PhotonView photon;

    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
       PhotonNetwork.GameVersion = version;
    }
    void Start()
    {
        tankbarrel=gameObject.transform.GetChild(0).gameObject.transform;
      
      
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(photon.IsMine)
        MousePointer();
        
    }

    void MousePointer()
    {
        y = Input.GetAxis("Mouse X")*400*Time.deltaTime;
        x = Input.GetAxis("Mouse Y") * 400 * Time.deltaTime;
        if (tankbarrel != null)
        {
            tankbarrel.RotateAround(transform.position, Vector3.forward, -y);
            if(x > 0)
            tankbarrel.RotateAround(transform.position, Vector3.forward, -x);
            if(x < 0)
                tankbarrel.RotateAround(transform.position, Vector3.forward, +x);

        }
    }
}
