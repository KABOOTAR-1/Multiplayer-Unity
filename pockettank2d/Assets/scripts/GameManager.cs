using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
public class GameManager : MonoBehaviour
{
    [SerializeField] private string version = "0.1";
    // Start is called before the first frame update
    public GameObject PlayerPrefab;
    public GameObject GameCanvas;
    public GameObject SceneCamera;
    public GameObject Check;
    public TMP_Text MyplayerHeatlh;
    public TMP_Text enemyHeatlh;

    private void Awake()
    {
        PhotonNetwork.GameVersion = version;
        PhotonNetwork.ConnectUsingSettings();
    }
    void Start()
    {
        Screen.fullScreenMode = FullScreenMode.Windowed;
        Screen.SetResolution(960, 540, false, 60);
    }

    
public void SpawnPlayer()
    {
        var randomValue = Random.Range(-1, 1);
      Check=  PhotonNetwork.Instantiate(PlayerPrefab.name, new Vector2(this.transform.position.x * randomValue, this.transform.position.y), Quaternion.identity, 0);
        GameCanvas.SetActive(false);
        SceneCamera.SetActive(false);
    }
    void Update()
    {
        if (Check != null)
        {
            if (Check.GetComponent<PhotonView>().IsMine)
            {
                Check.tag = "Player";
            }
            if(!Check.GetComponent<PhotonView>().IsMine)
            {
                Check.tag = "Enemy";
            }
        }
    }

    /*void SETHEALTH()
    {
        if (Check.GetComponent<PhotonView>().isMine)
        {
            
        }
    }*/
}
