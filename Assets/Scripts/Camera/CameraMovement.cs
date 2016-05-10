using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraMovement : MonoBehaviour {
    
    private float m_speed;
    [SerializeField]
    private float m_maxX_Right;
    [SerializeField]
    private float m_maxX_Left;
    [SerializeField]
    private float m_max_Height;
    private float m_min_Height;

    Camera m_mainCam;
    private List<GameObject> m_players;
    private Vector3 barycenter;

    private bool m_exitLeft, m_exitRight, m_exitDown, m_allInside;

	// Use this for initialization
	void Start () {
        m_players = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
        m_min_Height = transform.position.y;
        m_mainCam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {

        m_speed = m_players[0].GetComponent<PlayerMove>().getCurrentSpeed();
        m_exitRight = false;
        m_exitLeft = false;
        m_exitDown = false;
        m_allInside = true;

        Vector3 viewPos;

        for(int i = 0; i < m_players.Count; i++)
        {
            viewPos = m_mainCam.WorldToViewportPoint(m_players[i].transform.position);

            if (viewPos.x > 0.9f)
            {
                m_speed = Mathf.Max(m_speed, m_players[i].GetComponent<PlayerMove>().m_CurrentSpeed);
                m_exitRight = true;
            }

            if (viewPos.x < 0.1f)
            {
                m_speed = Mathf.Max(m_speed, m_players[i].GetComponent<PlayerMove>().m_CurrentSpeed);
                m_exitLeft = true;
            }

            if (viewPos.y < 0.1f)
            {
                m_speed = Mathf.Max(m_speed, m_players[i].GetComponent<PlayerMove>().m_CurrentSpeed);
                m_exitDown = true;
            }

            if (viewPos.x > 0.85f || viewPos.x < 0.15f || viewPos.y < 0.15f)
                m_allInside = false;
            else
                m_speed = Mathf.Max(m_speed, m_players[i].GetComponent<PlayerMove>().m_CurrentSpeed);
        }

        Debug.Log(m_speed);

        float moveSpeed = m_speed * Time.deltaTime;

        if (m_exitLeft && m_exitRight)
        {
            transform.Translate(new Vector3(0.0f, -moveSpeed/2, -moveSpeed));
        }
        else
        {
            if (m_exitLeft && transform.position.x > m_maxX_Left)
                transform.Translate(new Vector3(-moveSpeed, 0.0f, 0.0f));

            if(m_exitRight && transform.position.x < m_maxX_Right)
                transform.Translate(new Vector3(moveSpeed, 0.0f, 0.0f));
        }

        if(m_exitDown && transform.position.y < m_max_Height)
        {
            transform.Translate(new Vector3(0.0f, -moveSpeed/2, -moveSpeed));
        }

        if (m_allInside && transform.position.y > m_min_Height)
        {
            transform.Translate(new Vector3(0.0f, moveSpeed/2, moveSpeed));
        }
    }
}
