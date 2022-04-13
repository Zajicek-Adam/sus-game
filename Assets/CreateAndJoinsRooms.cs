using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class CreateAndJoinsRooms : MonoBehaviourPunCallbacks
{
    public TMP_InputField nameInput;

    public void CreateRoom()
    {
        if (nameInput.text != "")
        {
            PhotonNetwork.CreateRoom(nameInput.text);
        }
    }
    public void JoinRoom()
    {
        if (nameInput.text != "")
        {
            PhotonNetwork.JoinRoom(nameInput.text);
        }
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game"); //SceneManager for multiplayer
    }
}
