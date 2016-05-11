using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerUI : MonoBehaviour {

    [SerializeField]
    private List<GameObject> m_BulletUIList = new List<GameObject>();
    private Player m_Player;
    private int m_PlayerId;

    private int m_NumberBullet;

    void Start()
    {
        m_Player = GetComponent<Player>();
        m_PlayerId = m_Player.m_PlayerId;
        m_NumberBullet = 0;
    }

    public void DecrementBullets(int _playerId)
    {
        Animator _bulletAnimator = m_BulletUIList[m_NumberBullet].GetComponent<Animator>();
        m_NumberBullet++;
        _bulletAnimator.SetInteger("AnimNumber", Random.Range(1, 4));
    }

    public void ReloadBullets(int _playerId)
    {
        for (int i = 0; i < m_NumberBullet; i++)
        {
            Animator _bulletAnimator = m_BulletUIList[i].GetComponent<Animator>();
            _bulletAnimator.SetInteger("AnimNumber", 0);
        }
        m_NumberBullet = 0;
    }

}
