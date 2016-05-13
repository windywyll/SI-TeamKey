using UnityEngine;
using System.Collections;

public class AppearSheep : MonoBehaviour {

    public GameObject m_Sheep01;
    public GameObject m_Sheep02;
    public GameObject m_Sheep03;
    public GameObject m_Sheep04;

    // Use this for initialization
    void Start ()
    {
	    switch (PlayerPrefs.GetInt("PlayerNumber"))
        {
            case 2:
                m_Sheep03.SetActive(false);
                m_Sheep04.SetActive(false);
                break;

            case 3:
                m_Sheep04.SetActive(false);
                break;

        }
	}
	


	// Update is called once per frame
	void Update () {
	
	}
}
