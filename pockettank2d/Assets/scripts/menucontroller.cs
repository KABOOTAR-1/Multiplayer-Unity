using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
public class menucontroller : MonoBehaviourPunCallbacks
{
    [SerializeField] private string version = "0.1";
    [SerializeField] private GameObject UserName;
    [SerializeField] private GameObject ConnectPanel;
    [SerializeField] private TMP_InputField UsernameInput;
    [SerializeField] private TMP_InputField createGameInput;
    [SerializeField] private TMP_InputField JoinGameInput;
    [SerializeField] private GameObject StartButton;
    // Start is called before the first frame update
    void Awake()
    {
        PhotonNetwork.GameVersion = version;    
       PhotonNetwork.ConnectUsingSettings(); 
    }
    private void Start()
    {
        UserName.SetActive(true);
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(Photon.Realtime.TypedLobby.Default);
        Debug.Log("Connected");
    }
    void Update()
    {
        
    }

    public void ChangeUserName()
    {
        if(UsernameInput.text.Length >= 3)
        {
           StartButton.SetActive(true);
        }
        else
        {
            StartButton.SetActive(false);
        }
    }

    public void SetUserName()
    {
        UserName.SetActive(false );
        PhotonNetwork.LocalPlayer.NickName=UsernameInput.text;
    }

    
    public void CreateGame()
    {
        PhotonNetwork.CreateRoom(createGameInput.text,new Photon.Realtime.RoomOptions() { MaxPlayers=2}, Photon.Realtime.TypedLobby.Default);
    }
    public void JoinGame()
    {
       Photon.Realtime.RoomOptions roomoptions = new Photon.Realtime.RoomOptions();
        roomoptions.MaxPlayers = 2;
        PhotonNetwork.JoinOrCreateRoom(JoinGameInput.text, roomoptions,Photon.Realtime.TypedLobby.Default);

    }
   
     public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("MainGame");
    }
    
}
