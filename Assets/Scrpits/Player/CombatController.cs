using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    [SerializeField]
    private Transform m_AttackPoint;

    [SerializeField]
    private List<GameObject> m_Spells;

    [SerializeField]
    private int[] m_EquipedSpells;

    [SerializeField]
    private int m_iCurrentIndex;

    GameObject m_LeftMouse;
    GameObject m_RightMouse;

    private void Update()
    {
        if (Input.GetButtonDown("AttackLeft") && m_LeftMouse == null && m_RightMouse == null)
        {
            m_LeftMouse = Instantiate(m_Spells[m_EquipedSpells[m_iCurrentIndex]], m_AttackPoint.position, m_AttackPoint.rotation);
            m_LeftMouse.transform.parent = m_AttackPoint.transform;
        }
        else if (Input.GetButtonDown("AttackRight") && m_LeftMouse == null && m_RightMouse == null)
        {
            m_RightMouse = Instantiate(m_Spells[m_EquipedSpells[m_iCurrentIndex+1]], m_AttackPoint.position, m_AttackPoint.rotation);
            m_RightMouse.transform.parent = m_AttackPoint.transform;
        }

        if (m_LeftMouse != null && Input.GetButtonUp("AttackLeft"))
        {
            Destroy(m_LeftMouse);
        }

        if (m_RightMouse != null && Input.GetButtonUp("AttackRight"))
        {
           Destroy(m_RightMouse);
        }

        if (Input.GetButtonDown("SwitchSkills"))
        {
            if (Input.GetAxis("SwitchSkills") > 0)
            {
                m_iCurrentIndex += 2;
                if (m_iCurrentIndex > m_EquipedSpells.Length - 1)
                {
                    m_iCurrentIndex = 0;
                }
            }
            else if (Input.GetAxis("SwitchSkills") < 0)
            {
                m_iCurrentIndex -= 2;
                if (m_iCurrentIndex < 0)
                {
                    m_iCurrentIndex = m_EquipedSpells.Length - 2;
                }
            }            
        }
    }
}
