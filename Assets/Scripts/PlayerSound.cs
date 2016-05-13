using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public enum PlayerSoundType
{
    Dash,
    Hit,
    Shoot,
    Ulti
}

public class PlayerSound : MonoBehaviour {

    public AudioSource m_DashSource;
    public AudioSource m_HitSource;
    public AudioSource m_ShootSource;
    public AudioSource m_UltiSource;

    public AudioClip m_DashClip;
    public AudioClip m_HitClip;
    public AudioClip m_ShootClip;
    public AudioClip m_UltiClip;

    public void PlaySound(PlayerSoundType _playerSoundType)
    {
        switch (_playerSoundType)
        {
            case PlayerSoundType.Dash:
                m_DashSource.loop = false;
                m_DashSource.Stop();
                m_DashSource.clip = m_DashClip;
                m_DashSource.Play();
                break;
            case PlayerSoundType.Hit:
                m_HitSource.loop = false;
                m_HitSource.Stop();
                m_HitSource.clip = m_HitClip;
                m_HitSource.Play();
                break;
            case PlayerSoundType.Shoot:
                m_ShootSource.loop = false;
                m_ShootSource.Stop();
                m_ShootSource.clip = m_ShootClip;
                m_ShootSource.Play();
                break;
            case PlayerSoundType.Ulti:
                m_UltiSource.loop = false;
                m_UltiSource.Stop();
                m_UltiSource.clip = m_UltiClip;
                m_UltiSource.Play();
                break;
        }







    }
}
