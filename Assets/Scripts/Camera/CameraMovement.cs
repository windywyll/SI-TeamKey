﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraMovement : MonoBehaviour {

    private List<GameObject> m_players;
    private Vector3 barycenter;

	// Use this for initialization
	void Start () {
        m_players = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
	}
	
	// Update is called once per frame
	void Update () {
        barycenter = Vector3.zero;

	    for(int i = 0; i < m_players.Count; i++)
        {
            barycenter += m_players[i].transform.position;
        }

        barycenter /= ((float) m_players.Count);

        Vector3 newPos = new Vector3(barycenter.x, transform.position.y, transform.position.z);

        this.transform.position = newPos;

        this.transform.LookAt(barycenter);
	}
}