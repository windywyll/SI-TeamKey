using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public int m_PlayerNumber;

    public GameObject m_Player;

    public Player[] m_PlayerArray = new Player[4];

    int m_PlayerDieCounter = 0;



	// Use this for initialization
	void Awake ()
    {
        PlayerInstantiation();
        SoundManagerEvent.music(MusicType.InGame);
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
        _go.GetComponent<Player>().m_GameManager = this;
        GetComponent<DataSorting>().AddData(_go.GetComponent<PlayerData>());
        return _go.GetComponent<Player>();
    }

    public void AddDiedPlayer()
    {
        m_PlayerDieCounter++;
        if(m_PlayerDieCounter>=m_PlayerNumber)
        {
            LooseGame();
        }
    }
    public void SubDiedPlayer()
    {
        m_PlayerDieCounter--;
    }

    void LooseGame()
    {
        SoundManagerEvent.music(MusicType.Defeat);
        Invoke("ReturnMenu", 3);
    }

    void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

}
