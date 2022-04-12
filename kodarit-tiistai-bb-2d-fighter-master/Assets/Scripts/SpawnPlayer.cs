using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject[] playePreFabs;

    private float posY = 0f;
    private float player1xPos = -5f;
    private float player2xpos = 5f;

    private Vector2 spawnPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
