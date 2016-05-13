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
        //StartCoroutine("ReloadUICoroutine");
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

    //public void ReloadUIManager()
    //{
    //    m_UIElement.anchoredPosition = Camera.main.WorldToScreenPoint(m_Player.transform.position);
    //    StartCoroutine("ReloadUICoroutine");
    //}

    //IEnumerator ReloadUICoroutine()
    //{
    //    while (true)
    //    {
    //        //0,0 for the canvas is at the center of the screen, whereas WorldToViewPortPoint treats the lower left corner as 0, 0.Because of this, you need to subtract the height / width of the canvas * 0.5 to get the correct position.
    //        Vector2 _viewportPosition = Camera.main.WorldToViewportPoint(m_Player.transform.position);
    //        Vector2 _playerScreenPosition = new Vector2((_viewportPosition.x * m_CanvasRect.sizeDelta.x) - (m_CanvasRect.sizeDelta.x * 0.5f),
    //                                                    (_viewportPosition.y * m_CanvasRect.sizeDelta.y) - (m_CanvasRect.sizeDelta.y * 0.5f));
            
    //        m_UIElement.anchoredPosition = _playerScreenPosition;
            
    //        yield return 0;
    //    }
    //}




}
