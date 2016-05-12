using UnityEngine;
using UnityEngine.UI;
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

    [SerializeField]
    GameObject m_PlayerWorldUI;
    PlayerWorldUI[] m_PlayerWorldUIArray = new PlayerWorldUI[4];

    public void AddPlayerWorldUI(int _playerId, GameObject _player)
    {
        GameObject _goUI = Instantiate(m_PlayerWorldUI, _player.transform.position, Quaternion.identity) as GameObject;
        _goUI.name = "PlayerUI" + _playerId;
        m_PlayerWorldUIArray[_playerId - 1] = _goUI.GetComponent<PlayerWorldUI>();
        _goUI.GetComponent<PlayerWorldUI>().m_Player = _player;
    }

    public void PlayerWorldUIAnnounce(int _playerId, bool _state)
    {
        m_PlayerWorldUIArray[_playerId - 1].transform.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetInteger("State", 1);
    }

    public void PlayerWorldUIReloading(int _playerId, float _cooldownReload)
    {
        StartCoroutine(PlayerWorldUIReloadingCoroutine(_playerId, _cooldownReload));
    }

    IEnumerator PlayerWorldUIReloadingCoroutine(int _playerId, float _cooldownReload)
    {
        m_PlayerWorldUIArray[_playerId - 1].transform.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetInteger("State", 2);
        Image _reloadingBar = m_PlayerWorldUIArray[_playerId - 1].transform.GetChild(0).transform.GetChild(1).GetComponent<Image>();

        float _time = 0;

        while (_time < _cooldownReload)
        {
            _reloadingBar.fillAmount = Mathf.Lerp(0, 1, _time / _cooldownReload);
            _time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        _reloadingBar.fillAmount = 0;
        m_PlayerWorldUIArray[_playerId - 1].transform.GetChild(0).transform.GetChild(0).GetComponent<Animator>().SetInteger("State", 0);
    }


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
