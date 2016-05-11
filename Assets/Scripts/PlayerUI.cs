using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerUI : MonoBehaviour {

    [SerializeField]
    private List<GameObject> m_BulletUIList = new List<GameObject>();

    [SerializeField]
    private Image m_LifeBarImage;
    private int m_NumberBullet;

    void Start()
    {
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

    public void LifeManager(int _playerId, float _currentLife, float _newLife)
    {
        StopCoroutine("LifeManagerCoroutine");
        StartCoroutine(LifeManagerCoroutine(_playerId, _currentLife, _newLife));
    }

    IEnumerator LifeManagerCoroutine(int _playerId, float _startLife, float _newLife)
    {
        // Getting the life before the Lerp.
        float _currentLife = _startLife;

        // Preparing timer and Lerp's duration
        float _timer = 0;
        float _timerMax = 0.2f;

        
        while (_currentLife != _newLife)
        {
            yield return 0;
            _timer += Time.deltaTime;
            _currentLife = Mathf.Lerp(_startLife, _newLife, _timer / _timerMax);
            m_LifeBarImage.material.SetFloat("_Life", _currentLife / 100);
        }
    }

}
