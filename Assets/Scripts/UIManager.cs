﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIManager : MonoBehaviour {

    #region Singleton
    public static UIManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    #endregion

    [SerializeField]
    PlayerUI[] m_PlayerUIArray = new PlayerUI[4];


    public void DecrementBullet(int _playerId)
    {
        if (_playerId > 0)
        {
            m_PlayerUIArray[_playerId - 1].DecrementBullets(_playerId);
        }        
    }

    public void ReloadBullets(int _playerId)
    {
        if (_playerId > 0)
        {
            m_PlayerUIArray[_playerId - 1].ReloadBullets(_playerId);
        }
    }

    public void LifeManager(int _playerId, float _currentLife, float _newLife)
    {
        if (_playerId > 0)
        {
            m_PlayerUIArray[_playerId - 1].LifeManager(_playerId, _currentLife, _newLife);
        }
    }


}
