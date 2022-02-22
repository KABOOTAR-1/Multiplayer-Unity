using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class ChechCollision : MonoBehaviourPun
{ 

    public PhotonView photon;
public Player player;
    int players;
    Vector3 pos;

    public bool IsFiring { get; private set; }
 
    private void Awake()
    {
        photon=GetComponent<PhotonView>();
    }
    void Start()
    {

    }

   
    // Update is called once per frame
    void Update()
    {
       
    }

    
     
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!photonView.IsMine)
        {
            return;
        }
      
        PhotonView targets = collision.gameObject.GetComponent<PhotonView>();

        if (targets != null && (targets.IsMine || targets.IsRoomView))
        {
             
            if (targets.tag == "Player" )
            { 
                Debug.Log("Self Attack");
            }
            

        }
        else if(targets!=null && (!targets.IsMine || targets.IsRoomView))
        {
            if (targets.tag == "Player")
            {
                Debug.Log(" Attack");
            }
        }
        this.GetComponent<PhotonView>().RPC("Destroy", RpcTarget.AllBuffered);

    }

    [PunRPC]
     public void Destroy()
    {
        Destroy(this.gameObject);
    }

}
