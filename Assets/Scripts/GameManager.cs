using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GameManager : MonoBehaviour {

    public int m_PlayerNumber;

    public GameObject m_Player;

    public Player[] m_PlayerArray = new Player[4];

	// Use this for initialization
	void Awake ()
    {
        PlayerInstantiation();
	}
	
    void PlayerInstantiation()
    {
        if (m_PlayerNumber == 0)
        {
            m_PlayerNumber = PlayerPrefs.GetInt("PlayerNumber", 0);
            if (m_PlayerNumber == 0)
            {
                m_PlayerNumber = 1;
            }
            PlayerInstantiation();
        }
        else
        {
            for(int i=m_PlayerNumber; i>0; i--)
            {
                
                m_PlayerArray[i-1]= PlayerInstantiate(i);
            }
        }
    }

    Player PlayerInstantiate(int _id)
    {
        GameObject _go = Instantiate(m_Player, Vector3.zero, Quaternion.identity) as GameObject;
        _go.GetComponent<Player>().m_PlayerId = _id;
        GetComponent<DataSorting>().AddData(_go.GetComponent<PlayerData>());
        return _go.GetComponent<Player>();
    }

}
