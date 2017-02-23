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

    private void Start()
    {

    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(m_Spells[m_EquipedSpells[m_iCurrentIndex]], m_AttackPoint.position, m_AttackPoint.rotation);
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            Instantiate(m_Spells[m_EquipedSpells[m_iCurrentIndex+1]], m_AttackPoint.position, m_AttackPoint.rotation);
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
