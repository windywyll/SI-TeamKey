using UnityEngine;
using System.Collections;

public class PlayerData : MonoBehaviour {

    public int m_PlayerId;

    public int m_DamagesTotal;
    public int m_DamagesTaken;
    public int m_BulletsLaunched;
    public int m_BulletsTouched;
    public float m_Accuracy;
    public int m_PlayersRez;
    public int m_DeathNumber;
    public float m_Meters;
    public int m_Dash;

    bool m_Record = false;

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
    public void AddDamages(int _value)
    {
        m_DamagesTotal += _value;
    }

    public void AddDamagesTaken(int _value)
    {
        m_DamagesTaken += _value;
    }

    public void AddBulletsLaunched()
    {
        m_BulletsLaunched++;
    }

    public void AddBulletsTouched()
    {
        m_BulletsTouched++;
        CalculateAccuracy();
    }

    public void AddPlayerRez()
    {
        m_PlayersRez++;
    }

    public void AddDeath()
    {
        m_DeathNumber++;
    }

    public void AddMeters(float _meters)
    {
        m_Meters += _meters;
    }

    public void AddDash()
    {
        m_Dash++;
    }


    //Calcul
    void CalculateAccuracy()
    {
        m_Accuracy = (m_BulletsTouched / m_BulletsLaunched)*100;
    }


    //EndOfGame
    void CalculWhatToShow()
    {

    }

}
