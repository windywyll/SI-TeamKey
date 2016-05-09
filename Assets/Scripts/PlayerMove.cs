using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    //Access to the main class

    //Access to the Rigidbody Component
    private Rigidbody m_Rigidbody;


    //Stock the player ID, for Multiplayer
    private int m_PlayerId;

    // Displacement
    public float m_BaseSpeed;
    public float m_MaxSpeed;
    public float m_MinSpeed;
    public float m_Accel;
    public float m_Deccel;
    public Vector3 m_Direction = Vector3.zero;

    public float m_ClampRotMax;
    public float m_AccelRot;
    public float m_ClampRotMin;

    public float m_CurrentSpeed = 0.0f;

    //Imput
    private bool m_isInputDetected = true;
    private bool m_UpImput;
    private bool m_DownImput;
    private bool m_LeftImput;
    private bool m_RightImput;

    //Animation
    Animator m_Animator;

    // Use this for initialization
    void Start()
    {



        //<GETCOMPONENT>{
        //Animator
        m_Animator = GetComponent<Animator>();
        //Get the rigidbody
        m_Rigidbody = GetComponent<Rigidbody>();

        m_PlayerId = GetComponent<Player>().m_PlayerId;

        InitializeInput();
    }

    void InitializeInput()
    {
        m_UpImput = false;
        m_DownImput = false;
        m_LeftImput = false;
        m_RightImput = false;
    }


   /*
    public void Vibrate()
    {
        GetComponent<Vibrations>().SetVibration(true, 0.2f);
        Invoke("StopVibration", 0.2f);
    }
    */

    void InputDetection()
    {

        if (m_isInputDetected)
        {

            #region Gamepad
            if (Input.GetAxis("L_XAxis_"+m_PlayerId.ToString()) < 0)
            {
                m_LeftImput = true;
            }
            else
            {
                m_LeftImput = false;

            }
            if (Input.GetAxis("L_XAxis_" + m_PlayerId.ToString()) > 0)
            {
                m_RightImput = true;

            }
            else
            {
                m_RightImput = false;
            }
            if (Input.GetAxis("L_YAxis_" + m_PlayerId.ToString()) < 0)
            {
                m_UpImput = true;
            }
            else
            {
                m_UpImput = false;
            }
            if (Input.GetAxis("L_YAxis_" + m_PlayerId.ToString()) > 0)
            {
                m_DownImput = true;
            }
            else
            {
                m_DownImput = false;
            }
            #endregion

            #region Keyboard
            /*
            #region Keyboard
            if (Input.GetKey("up") || Input.GetKey(KeyCode.Z))
            {
                m_UpImput = true;
                if (m_IsUsingGamePad == true)
                {
                    m_IsUsingGamePad = false;
                }
            }
            if (Input.GetKeyUp("up") && Input.GetKeyUp(KeyCode.Z))
            {
                m_UpImput = false;
            }

            if (Input.GetKey("down") || Input.GetKey(KeyCode.S))
            {
                m_DownImput = true;
                if (m_IsUsingGamePad == true)
                {
                    m_IsUsingGamePad = false;
                }
            }
            if (Input.GetKeyUp("down") && Input.GetKeyUp(KeyCode.S))
            {
                m_DownImput = false;
            }
            if (Input.GetKey("left") || Input.GetKey(KeyCode.Q))
            {
                m_LeftImput = true;
                if (m_IsUsingGamePad == true)
                {
                    m_IsUsingGamePad = false;
                }
            }
            if (Input.GetKeyUp("left") && Input.GetKeyUp(KeyCode.Q))
            {
                m_LeftImput = false;
            }

            if (Input.GetKey("right") || Input.GetKey(KeyCode.D))
            {
                m_RightImput = true;
                if (m_IsUsingGamePad == true)
                {
                    m_IsUsingGamePad = false;
                }
            }
            if (Input.GetKeyUp("right") && Input.GetKeyUp(KeyCode.D))
            {
                m_RightImput = false;
            }
            #endregion
            */
            #endregion

        }
    }

    void Rotate()
    {

        if ((Input.GetAxis("R_XAxis_1") != 0) || (Input.GetAxis("R_YAxis_1") != 0))
        {
            Vector3 rotatePos = new Vector3((Input.GetAxis("R_XAxis_1")), (Input.GetAxis("R_YAxis_1")) * -1, 0);
            rotatePos.z = 0;
            //rotatePos.z = 5.23f;
            /*
             Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
             mousePos.x = mousePos.x - objectPos.x;
             mousePos.y = mousePos.y - objectPos.y;
             */
            float angle = Mathf.Atan2(rotatePos.y, rotatePos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, -(angle-90), 0 ));
            // last_mousePos = mousePos;
        }


        /*m_Rigidbody.angularVelocity = Vector3.zero;
        if (m_LeftImput ^ m_RightImput)
        {

                if (m_LeftImput && !m_RightImput)
                {
                    //Rotate Left
                    transform.Rotate(Vector3.down, m_RotateSpeed * Time.deltaTime);

                    m_IsRotatingLeft = true;
                    m_IsRotatingRight = false;

                }

                if (!m_LeftImput && m_RightImput)
                {
                    //Rotate Right
                    transform.Rotate(Vector3.up, m_RotateSpeed * Time.deltaTime);

                    m_IsRotatingLeft = false;
                    m_IsRotatingRight = true;

                }
            }

        */
    }

    void Update()
    {
        //QuickFix de la position en Y
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        //////Code QTE demarrage Tondeuse

            InputDetection();

            //Set the rotation
            Rotate();

        //Move the mower



        m_Direction = Vector3.zero;
        m_Direction += Vector3.back * Input.GetAxis("L_YAxis_" + m_PlayerId.ToString()) ;
        m_Direction += Vector3.right * Input.GetAxis("L_XAxis_" + m_PlayerId.ToString());

        m_Direction.Normalize();

        m_CurrentSpeed += Time.deltaTime * m_Accel;

        m_Rigidbody.velocity = m_Direction * m_CurrentSpeed;

        m_CurrentSpeed = Mathf.Clamp(m_CurrentSpeed, m_MinSpeed, m_MaxSpeed);
        //}
        
    }

    
}

/* BUTTON
if (Input.GetButtonDown("A_1"))
{
	Debug.Log("A");
}
if (Input.GetButtonDown("B_1"))
{
	Debug.Log("B");
}
if (Input.GetButtonDown("X_1"))
{
	Debug.Log("X");
}
if (Input.GetButtonDown("Y_1"))
{
	Debug.Log("Y");
}
if (Input.GetButtonDown("Start_1"))
{
	Debug.Log("Start");
}
if (Input.GetButtonDown("Back_1"))
{
	Debug.Log("Select");
}
if (Input.GetButtonDown("LB_1"))
{
	Debug.Log("LB");
}
if (Input.GetButtonDown("RB_1"))
{
	Debug.Log("RB");
}
if (Input.GetAxis("DPad_XAxis_1")>0)
{
	Debug.Log("Pad droit");
}
if (Input.GetAxis("DPad_XAxis_1") < 0)
{
	Debug.Log("Pad gauche");
}
if (Input.GetAxis("L_XAxis_1") < 0)
{
	Debug.Log("Stick Gauche Gauche");
}
if (Input.GetAxis("L_XAxis_1") > 0)
{
	Debug.Log("Stick Gauche Droit");
}
if (Input.GetAxis("L_YAxis_1") < 0)
{
	Debug.Log("Stick Gauche Haut");
}
if (Input.GetAxis("L_YAxis_1") > 0)
{
	Debug.Log("Stick Gauche Bas");
}
if (Input.GetAxis("R_XAxis_1") < 0)
{
	Debug.Log("Stick Droit Gauche");
}
if (Input.GetAxis("R_XAxis_1") > 0)
{
	Debug.Log("Stick Droit Droit");
}
if (Input.GetAxis("R_YAxis_1") < 0)
{
	Debug.Log("Stick Droit Haut");
}
if (Input.GetAxis("R_YAxis_1") > 0)
{
	Debug.Log("Stick Droit Bas");
}
 
Debug.Log("Gachette Droite "+Input.GetAxis("TriggersR_1"));
Debug.Log("Gachette Gauche " + Input.GetAxis("TriggersL_1"));
*/
