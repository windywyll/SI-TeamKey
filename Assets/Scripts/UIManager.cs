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

    public PlayerUI[] m_PlayerUIArray = new PlayerUI[4];

    [SerializeField]
    GameObject m_PlayerWorldUI;

    PlayerWorldUI[] m_PlayerWorldUIArray = new PlayerWorldUI[4];

    private bool m_IsReanimating = false;

    


    public void AddPlayerWorldUI(int _playerId, GameObject _player)
    {
        Debug.Log("Ici");
        GameObject _goUI = Instantiate(m_PlayerWorldUI, _player.transform.position, Quaternion.identity) as GameObject;
        _goUI.name = "PlayerUI" + _playerId;
        m_PlayerWorldUIArray[_playerId - 1] = _goUI.GetComponent<PlayerWorldUI>();
        _goUI.GetComponent<PlayerWorldUI>().m_Player = _player;
    }
    
    #region Reload
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
    #endregion

    #region BulletsAnim
    public void DecrementBullet(int _playerId)
    {
        if (_playerId > 0)
        {
            //Debug.Log(_playerId);
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
    #endregion

    #region Life
    public void LifeManager(int _playerId, float _currentLife, float _newLife)
    {
        if (_playerId > 0)
        {
            m_PlayerUIArray[_playerId - 1].LifeManager(_playerId, _currentLife, _newLife);
        }
    }
    #endregion

    #region Reanimation

    void RezButtonAnimManager(int _playerId, int _state)
    {
        m_PlayerWorldUIArray[_playerId - 1].transform.GetChild(0).transform.GetChild(2).GetComponent<Animator>().SetInteger("State", _state);
    }
    
    public void RezButtonDisplay(GameObject _deadPlayer)
    {
        int _playerId = _deadPlayer.GetComponent<Player>().m_PlayerId;
        Debug.Log("Display : id = " + _playerId);
        RezButtonAnimManager(_playerId, 1);
    }

    public void RezButtonHide(GameObject _deadPlayer)
    {
        int _playerId = _deadPlayer.GetComponent<Player>().m_PlayerId;
        Debug.Log("Hide : id = " + _playerId);
        RezButtonAnimManager(_playerId, 0);
    }

    public void RezButtonStop(GameObject _deadPlayer)
    {
        int _playerId = _deadPlayer.GetComponent<Player>().m_PlayerId;
        Debug.Log("Stop : id = " + _playerId);
        RezButtonAnimManager(_playerId, 1);
    }

    public void RezButtonLaunch(GameObject _playerAlive, int _playerId, float _timeRea)
    {
        Debug.Log("Display : id = " + _playerAlive.GetComponent<Player>().m_PlayerId);
        StartCoroutine(RezButtonLoading(_playerAlive, _playerId, _timeRea));
    }

    IEnumerator RezButtonLoading(GameObject _playerAlive, int _playerId, float _timeRea)
    {
        Debug.Log(_playerAlive.name);
        RezButtonAnimManager(_playerId, 2);
        float _time = 0;
        Image _rezLoading = m_PlayerWorldUIArray[_playerId - 1].transform.GetChild(0).transform.GetChild(3).GetComponent<Image>();
        bool _isReanimated = true;

        while (_time < _timeRea && _isReanimated)
        {
            _isReanimated = _playerAlive.GetComponent<PlayerReanimation>().GetReanimate();
            Debug.Log(_isReanimated);
            _rezLoading.fillAmount = Mathf.Lerp(0, 1, _time / _timeRea);
            _time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        if (_time >= _timeRea)
        {
            RezButtonAnimManager(_playerId, 0);
        }
        _rezLoading.fillAmount = 0;
        _isReanimated = false;
    }





















    //public void RezButtonDisplay(GameObject _deadPlayer)
    //{
    //    int _id = _deadPlayer.GetComponent<Player>().m_PlayerId;
    //    m_PlayerWorldUIArray[_id - 1].transform.GetChild(0).transform.GetChild(2).GetComponent<Animator>().SetInteger("State", 1);
    //}

    //public void RezButtonLaunch(GameObject _deadPlayer, float _timeRez)
    //{
    //    int _id = _deadPlayer.GetComponent<Player>().m_PlayerId;
    //    m_IsReanimating = true;
    //    StartCoroutine(RezButtonCoroutine(_id, _timeRez));
    //}

    //public void RezButtonStop(GameObject _deadPlayer)
    //{
    //    int _id = _deadPlayer.GetComponent<Player>().m_PlayerId;
    //    //////////////////////////////////////////////STOP COROUTINE
    //    m_IsReanimating = true;
    //    m_PlayerWorldUIArray[_id - 1].transform.GetChild(0).transform.GetChild(2).GetComponent<Animator>().SetInteger("State", 1);
    //    m_PlayerWorldUIArray[_id - 1].transform.GetChild(0).transform.GetChild(3).GetComponent<Image>().fillAmount = 0;
    //}

    //IEnumerator RezButtonCoroutine(int _playerId, float _timeRez)
    //{
    //    m_PlayerWorldUIArray[_playerId - 1].transform.GetChild(0).transform.GetChild(2).GetComponent<Animator>().SetInteger("State", 2);

    //    Image _rezLoading = m_PlayerWorldUIArray[_playerId - 1].transform.GetChild(0).transform.GetChild(3).GetComponent<Image>();
    //    float _time = 0;
    //    while (_time < _timeRez && m_IsReanimating)
    //    {
    //        _rezLoading.fillAmount = Mathf.Lerp(0, 1, _time / _timeRez);
    //        _time += Time.deltaTime;
    //        Debug.Log(_time);
    //        yield return new WaitForEndOfFrame();
    //    }
    //    m_IsReanimating = false;
    //    _rezLoading.fillAmount = 0;
    //    m_PlayerWorldUIArray[_playerId - 1].transform.GetChild(0).transform.GetChild(2).GetComponent<Animator>().SetInteger("State", 0);
    //}

    //public void RezButtonHide(GameObject _deadPlayer)
    //{
    //    m_IsReanimating = false;
    //    int _id = _deadPlayer.GetComponent<Player>().m_PlayerId;
    //    m_PlayerWorldUIArray[_id - 1].transform.GetChild(0).transform.GetChild(2).GetComponent<Animator>().SetInteger("State", 0);
    //}
    #endregion

}
