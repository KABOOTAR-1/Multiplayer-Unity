using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Shoot : MonoBehaviourPunCallbacks
{
    [SerializeField] private string version = "0.1";
    public GameObject Bullet;
   public GameObject barrel;
    Rigidbody2D rb;

    GameObject check;
    public PhotonView photon;

    public bool self;
    // Start is called before the first frame update
    private void Start()
    {
       
       PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.GameVersion = version;
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.F) && photonView.IsMine)
        {
            shoot();

        }

    }
  
    [PunRPC]
    public void shoot()
    {
        rb = PhotonNetwork.Instantiate(Bullet.name, barrel.transform.position, Quaternion.identity,0).GetComponent<Rigidbody2D>();
        
        rb.AddForce(barrel.transform.right * 8, ForceMode2D.Impulse);

    }
 
  
}
