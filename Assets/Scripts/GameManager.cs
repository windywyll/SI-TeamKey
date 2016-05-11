using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public int m_PlayerNumber;

    public GameObject m_Player;

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
                PlayerInstantiate(i);
            }
        }
    }

    void PlayerInstantiate(int _id)
    {
        GameObject _go = Instantiate(m_Player, Vector3.zero, Quaternion.identity) as GameObject;
        _go.GetComponent<Player>().m_PlayerId = _id;
    }

}
