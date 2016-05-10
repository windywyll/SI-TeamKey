using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraStepBack : MonoBehaviour {

    [SerializeField]
    Camera cam;
    [SerializeField]
    GameObject mainCam;
    [SerializeField]
    private float maxHeight;
    [SerializeField]
    private float minHeight;

    private List<GameObject> m_players;

    // Use this for initialization
    void Start () {
        m_players = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
    }
	
	// Update is called once per frame
	void Update () {
        bool outside = false;
        bool allInside = true;

        for (int i = 0; i < m_players.Count; i++)
        {
            //check if(m_players[i].notvisible) { outside = true;}
            Vector3 viewPos = cam.WorldToViewportPoint(m_players[i].transform.position);

            if (viewPos.z < 0.0f)
            {
                allInside = false;
                outside = true;
            }

            if (viewPos.x > 1.0f || viewPos.x < 0.0f)
            {
                allInside = false;
                outside = true;
            }

            if (viewPos.y > 1.0f || viewPos.y < 0.0f)
            {
                allInside = false;
                outside = true;
            }

            if (viewPos.x > 0.9f || viewPos.x < 0.1f)
                allInside = false;

            if (viewPos.y > 0.9f || viewPos.y < 0.1f)
                allInside = false;
        }
        
        if (outside && mainCam.transform.position.z > maxHeight)
        {
            this.transform.Translate(new Vector3(0.0f, 0.0f, -0.1f));
            mainCam.transform.Translate(new Vector3(0.0f, 0.0f, -0.1f));
        }

        if(allInside && mainCam.transform.position.z < minHeight)
        {
            this.transform.Translate(new Vector3(0.0f, 0.0f, 0.1f));
            mainCam.transform.Translate(new Vector3(0.0f, 0.0f, 0.1f));
        }
    }
}
