using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Camera;

    [SerializeField]
    private GameObject m_CamPivot;

    [SerializeField]
    private float m_fAcc;
    [SerializeField]
    private float m_fSpeed;

    private Rigidbody m_Rid;

    [SerializeField]
    private float m_fMouseSens;

    [SerializeField]
    private float m_fLeanAngle;

    [SerializeField]
    private float m_fLeanStep;

    [SerializeField]
    private float m_fSpeedTillBob;

    [SerializeField]
    private float m_fHeadBobStrength;

    [SerializeField]
    private float m_fBodStep;

    private bool m_BobTogggle;

    void Start()
    {
        m_Rid = GetComponent<Rigidbody>();
        MouseLock(1);
    }

    void Update()
    {
        Vector3 _v3Final = transform.forward;


        _v3Final += Input.GetAxis("MoveHor") * m_fAcc * transform.right;
        _v3Final += Input.GetAxis("MoveVer") * m_fAcc *transform.forward;

        if (m_Rid.velocity.magnitude < m_fSpeed)
        {
            m_Rid.AddForce(_v3Final,ForceMode.Acceleration);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            MouseLock(2);
        }

        if (Cursor.lockState == CursorLockMode.Locked)
        {
            Vector3 _MouseOffset = new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0f)*m_fMouseSens;
            transform.Rotate(0, _MouseOffset.y, 0);
            m_Camera.transform.Rotate(_MouseOffset.x, 0, 0);
            transform.LookAt(transform.position + transform.forward, Vector3.up);
        }

        if (Input.GetAxis("MoveHor") > 0)
        {
            m_CamPivot.transform.rotation = Quaternion.RotateTowards(m_CamPivot.transform.rotation, transform.rotation*Quaternion.Euler(Vector3.forward * m_fLeanAngle), m_fLeanStep * Time.deltaTime);
        }
        else if (Input.GetAxis("MoveHor") < 0)
        {
            m_CamPivot.transform.rotation = Quaternion.RotateTowards(m_CamPivot.transform.rotation, transform.rotation*Quaternion.Euler(Vector3.forward * -m_fLeanAngle), m_fLeanStep * Time.deltaTime);
        }
        else
        {
            m_CamPivot.transform.rotation = Quaternion.RotateTowards(m_CamPivot.transform.rotation, transform.rotation, m_fLeanStep * Time.deltaTime);
        }

        if (m_Rid.velocity.magnitude > m_fSpeedTillBob)
        {
            if (m_CamPivot.transform.position.y < transform.position.y + m_fHeadBobStrength && !m_BobTogggle)
            {
                m_CamPivot.transform.position = Vector3.MoveTowards(m_CamPivot.transform.position, transform.position + new Vector3(0, m_fHeadBobStrength, 0), m_fBodStep * Time.deltaTime);
            }
            else
            {
                m_BobTogggle = true;
            }

            if (m_CamPivot.transform.position.y > transform.position.y - m_fHeadBobStrength && m_BobTogggle)
            {
                m_CamPivot.transform.position = Vector3.MoveTowards(m_CamPivot.transform.position, transform.position - new Vector3(0, m_fHeadBobStrength, 0), m_fBodStep * Time.deltaTime);
            }
            else
            {
                m_BobTogggle = false;
            }
            
        }

        if (Input.GetButtonDown("Dash"))
        {
            if (Input.GetAxis("MoveHor") > 0)
            {
                m_CamPivot.transform.rotation = Quaternion.RotateTowards(m_CamPivot.transform.rotation, transform.rotation * Quaternion.Euler(Vector3.forward * (m_fLeanAngle+100)), m_fLeanStep * Time.deltaTime);
            }
            else if (Input.GetAxis("MoveHor") < 0)
            {
                m_CamPivot.transform.rotation = Quaternion.RotateTowards(m_CamPivot.transform.rotation, transform.rotation * Quaternion.Euler(Vector3.forward * (-m_fLeanAngle+100)), m_fLeanStep * Time.deltaTime);
            }
        }
    }

    public void MouseLock(int _LockType)
    {
        if (_LockType == 1)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (_LockType == 0)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else if (_LockType == 2)
        {
            if (Cursor.lockState == CursorLockMode.None)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            else if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
}
