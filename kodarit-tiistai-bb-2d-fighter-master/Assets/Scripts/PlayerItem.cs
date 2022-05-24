using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using UnityEngine.UI;

public class PlayerItem : MonoBehaviourPunCallbacks
{
	public GameObject NextButton;
    public GameObject PreviousButton;
    public SpriteRenderer PlayerAvatar;
    public Sprite[] Avatars;
    ExitGames.Client.Photon.Hashtable PlayerProperties = new ExitGames.Client.Photon.Hashtable();
    Player Player;

    public void ApplyLocalChanges()
    {
        PreviousButton.SetActive(false);
        NextButton.SetActive(false);
    }

    public void SetPlayerInfo(Player _player)
    {
        Player = _player;
        UpdatePlayerItem(Player);
    }

    public void OnClickPreviousButton()
    {
        if ((int)PlayerProperties["PlayerAvatar"] == 0)
        {
            PlayerProperties["PlayerAvatar"] = Avatars.Length - 1;
        }
        else 
        {
            PlayerProperties["PlayerAvatar"] = (int)PlayerProperties["PlayerAvatar"] - 1;
        }
        PhotonNetwork.SetPlayerCustomProperties(PlayerProperties);
    }

    public void OnClickNextButton() 
    {
        if ((int)PlayerProperties["PlayerAvatar"] == Avatars.Length - 1)
        {
            PlayerProperties["PlayerAvatar"] = 0;
        }
        else 
        {
            PlayerProperties["PlayerAvatar"] = (int)PlayerProperties["PlayerAvatar"] + 1;
        }
        PhotonNetwork.SetPlayerCustomProperties(PlayerProperties);
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable PlayerProperties) 
    {
        if (Player == targetPlayer) 
        {
            UpdatePlayerItem(targetPlayer);
        }
    }

	private void UpdatePlayerItem(Player Player)
	{
        if (Player.CustomProperties.ContainsKey("PlayerAvatar"))
        {
            PlayerAvatar.sprite = Avatars[(int)Player.CustomProperties["PlayerAvatar"]];
            PlayerProperties["PlayerAvatar"] = (int)Player.CustomProperties["PlayerAvatar"];
        }
        else 
        {
            PlayerProperties["PlayerAvatar"] = 0;
        }
	}
}
