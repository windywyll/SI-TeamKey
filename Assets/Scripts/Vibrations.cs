using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class Vibrations : MonoBehaviour {

    float m_ValueOfLeftVibrating=0 ;  //valeur de vibration gauche
    float m_ValueOfRightVibrating=0 ;  //valeur de vibration droite
    bool m_isVibrating = false;

    bool m_isVibrationModeActive = true;

    private int m_PlayerId;
    private PlayerIndex m_PlayerIndex;

    void Start()
    {
        m_PlayerId = GetComponent<Player>().m_PlayerId;

        switch (m_PlayerId)
        {
            case 1:
                m_PlayerIndex = PlayerIndex.One;
                break;

            case 2:
                m_PlayerIndex = PlayerIndex.Two;
                break;

            case 3:
                m_PlayerIndex = PlayerIndex.Three;
                break;

            case 4:
                m_PlayerIndex = PlayerIndex.Four;
                break;
        }

    }

    // Vibrations On/Off
    public void SetVibration (bool newVib)
    {
        if(m_isVibrationModeActive)
        {
            if (!newVib)
            {
                m_ValueOfLeftVibrating = 0;
                m_ValueOfRightVibrating = 0;
                m_isVibrating = false;
            }
            else
            {
                m_ValueOfLeftVibrating = 0.2f;
                m_ValueOfRightVibrating = 0.2f;
                m_isVibrating = true;
            }
        }
       
        //&GamePad.SetVibration(PlayerIndex.One, testA, testB);
    }

    public void SetVibration(bool _isVibrating, float _value)
    {
       
        if (m_isVibrationModeActive)
        {
            
            if (!_isVibrating)
            {
                m_ValueOfLeftVibrating = 0;
                m_ValueOfRightVibrating = 0;
                m_isVibrating = false;
            }
            else
            {
                m_ValueOfLeftVibrating = _value;
                m_ValueOfRightVibrating = _value;
                m_isVibrating = true;
            }
        }
    }

    public void SetVibration(float _value, float _time)
    {

        if (m_isVibrationModeActive)
        {

            if (_value>0)
            {
                m_ValueOfLeftVibrating = _value;
                m_ValueOfRightVibrating = _value;
                m_isVibrating = true;

                Invoke("StopVibration", _time);
            }

        }
    }

    public void SetVibration(float _valueLeft, float _valueRight, float _time)
    {

        if (m_isVibrationModeActive)
        {

                m_ValueOfLeftVibrating = _valueLeft;
                m_ValueOfRightVibrating = _valueRight;
                m_isVibrating = true;

                Invoke("StopVibration", _time);
        }
    }

    void StopVibration()
    {
        m_ValueOfLeftVibrating = 0;
        m_ValueOfRightVibrating = 0;
        m_isVibrating = false;
    }

    public void ActivateVibration(bool _isActivate)
    {
        m_isVibrationModeActive = _isActivate;

        if(m_isVibrating)
        {
            m_ValueOfLeftVibrating = 0;
            m_ValueOfRightVibrating = 0;
            m_isVibrating = false;
        }
    }

    public void ShootVibration()
    {
        SetVibration(Random.Range(0.2f,0.4f), 0.1f);
    }

    public void ReloadVibration(bool _first)
    {
        SetVibration(0, 0.7f, 0.2f);
    }

    public void DashVibration(float _time)
    {
        StartCoroutine(Dash(_time));
    }

    IEnumerator Dash(float _time)
    {
        SetVibration(0, 0.7f, 0.1f);
        yield return new WaitForSeconds(_time);
        SetVibration(1f, 0, 0.1f);
    }

    

    void Update()
    {
        if(m_isVibrationModeActive)
        {
            GamePad.SetVibration(m_PlayerIndex, m_ValueOfLeftVibrating, m_ValueOfRightVibrating);
        }
        

        if (Input.GetButtonDown("Start_"+ m_PlayerId.ToString()))
        {
            ActivateVibration(!m_isVibrationModeActive);
        }

        if (Input.GetButtonDown("B_" + m_PlayerId.ToString()))
        {
            m_ValueOfLeftVibrating = 0;
            m_ValueOfRightVibrating = 0.5f;
            m_isVibrating = true;

            Invoke("StopVibration", 0.5f);
        }
        if (Input.GetButtonDown("Y_" + m_PlayerId.ToString()))
        {
            m_ValueOfLeftVibrating = 0.2f;
            m_ValueOfRightVibrating = 0;
            m_isVibrating = true;

            Invoke("StopVibration", 0.5f);
        }

    }

    void OnApplicationQuit()
    {
        GamePad.SetVibration(m_PlayerIndex, 0, 0);
    }

}

