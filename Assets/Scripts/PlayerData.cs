using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum DataType
{
    DamagesTotal,
    DamagesTaken,
    BulletsLaunched,
    BulletsTouched,
    Accuracy,
    DeathNumber,
    Meters,
    Dash,
    PlayersRez
}


public class PlayerData : MonoBehaviour {

    public int m_PlayerId;

    public int m_DamagesTotal;
    public int m_DamagesTaken;
    public int m_BulletsLaunched;
    public int m_BulletsTouched;
    public int m_Accuracy;
    public int m_PlayersRez;
    public int m_DeathNumber;
    public int m_Meters;
    public int m_Dash;

    private float meter;

    bool m_Record = true;

    

    // Use this for initialization
    void Start ()
    {
        m_PlayerId = GetComponent<Player>().m_PlayerId;

        m_DamagesTotal =0;
        m_DamagesTaken=0;
        m_BulletsLaunched=0;
        m_Accuracy=0;
        m_PlayersRez=0;
        m_DeathNumber=0;
        m_BulletsTouched = 0;
        m_Meters = 0;
        m_Dash = 0;
    }


    //Import
    #region Import
    public void AddDamages(int _value)
    {
        if(m_Record)
        m_DamagesTotal += _value;
    }

    public void AddDamagesTaken(int _value)
    {
        if (m_Record)
            m_DamagesTaken += _value;
    }

    public void AddBulletsLaunched()
    {
        if (m_Record)
            m_BulletsLaunched++;
    }

    public void AddBulletsTouched()
    {
        if (m_Record)
        {
            m_BulletsTouched++;
            CalculateAccuracy();
        }
    }

    public void AddPlayerRez()
    {
        if (m_Record)
            m_PlayersRez++;
    }

    public void AddDeath()
    {
        if (m_Record)
            m_DeathNumber++;
    }

    public void AddMeters(float _meters)
    {
        if (m_Record)
        {
            meter += _meters;
            if(meter>1)
            {
                m_Meters += (int)meter;
                meter = 0;
            }
        }
            
    }

    public void AddDash()
    {
        if (m_Record)
            m_Dash++;
    }
    #endregion

    //Calcul
    void CalculateAccuracy()
    {
        m_Accuracy = (m_BulletsTouched / m_BulletsLaunched)*100;
    }

    
}
