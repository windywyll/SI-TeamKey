using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MotherWolfLinkAttacksAnimation : MonoBehaviour {

    [SerializeField]
    private MotherWolfBarrelAttack m_barrel;
    [SerializeField]
    private MotherWolfObjectRain m_objectRain;
    [SerializeField]
    private MotherWolfMotorAttack m_motor;
    [SerializeField]
    private MotherWolfRocketAttack m_missile;
    [SerializeField]
    private MotherWolf m_mother;

    public void launchRockets()
    {
        m_missile.launchMissiles();
    }

    public void launchMotor()
    {
        m_motor.launchMotor();
    }

    public void stopWeakness()
    {
        m_mother.stopBeingWeak();
    }
}
