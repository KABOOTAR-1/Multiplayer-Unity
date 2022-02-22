using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;
public class Player : MonoBehaviourPun
{
    public PhotonView photonview;
    public Transform GroundCheck;
    public GameObject PlayerCamera;
    public Text PlayerNameText;
    public LayerMask Ground;
    public LayerMask mainplayer;
    public bool isGrounded;
    float velocity;
    float gravity = -9.81f;
    public float gravityScale = 5;
    public float jumpForce = 20;
    public float offset = 0.1f;
    public ContactFilter2D filter;
    public Collider2D[] results = new Collider2D[1];
    public Vector2 surfacePosition;
    public bool collide=true;
    public TMP_Text Username;
    //PhotonTransformViewClassicEditor view;
    // Start is called before the first frame update

    private void Awake()
    {
        if (photonView.IsMine)
        {
            Username.text = PhotonNetwork.LocalPlayer.NickName;
        }
        else
        {
            Username.text = photonView.Owner.NickName;
            Username.color = Color.magenta;
        }
    }
    void Start()
    {
     

        filter.useLayerMask = true; 
       // filter.layerMask = Ground;
        //filter.layerMask = mainplayer;
        if (photonview.IsMine)
        {
            PlayerCamera.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (photonview.IsMine)
        {
            CheckInput();
            
        }

    }

    void CheckInput()
    {
        Vector3 realpos=transform.position;
        float x = Input.GetAxis("Horizontal");
        realpos += new Vector3(0.11f * x, 0);
        transform.localPosition = Vector3.MoveTowards(transform.position, realpos, Time.deltaTime * 10f);
        Vector2 point = transform.position + Vector3.down * offset;
        Vector2 size = new Vector2(transform.localScale.x, transform.localScale.y);

        if (Physics2D.OverlapBox(point, size, 0, filter, results) > 0)
        {
            isGrounded = true;
            surfacePosition = Physics2D.ClosestPoint(transform.position, results[0]);
        }
        else
        {
            isGrounded = false;
        }
        Jump();
        collide = true;

    }

    void Jump()
    {
        velocity += gravity * gravityScale * Time.deltaTime;
        if (isGrounded && velocity < 0)
        {
            
            float floorHeight = 0.5f;
            velocity = 0;
            Vector3 check = new Vector3(transform.position.x, surfacePosition.y + floorHeight, transform.position.z);
            transform.position = check;
        }
        if (Input.GetKeyDown(KeyCode.Space)&& isGrounded)
        {
            velocity = jumpForce;
            
        }
        transform.Translate(new Vector3(0, velocity, 0) * Time.deltaTime);
    }

    
}


 

