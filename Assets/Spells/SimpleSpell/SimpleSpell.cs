using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSpell : MonoBehaviour
{
    [SerializeField]
    private GameObject m_SimpleProj;

    [SerializeField]
    private float m_fAttackSpeed;

    static private float m_fCoolDown;

    private bool m_bCanAttack = true;

    [SerializeField]
    private float m_fProjSpeed;

    [SerializeField]
    private float m_fButtletSpreed;

    private void Update()
    {
        if (m_fCoolDown > 0)
        {
            m_fCoolDown -= Time.deltaTime;
        }
        else if (!m_bCanAttack)
        {
            m_bCanAttack = true;
        }

        if (m_bCanAttack)
        {
            GameObject _Poject = Instantiate(m_SimpleProj, transform.position + transform.up*Random.Range(-m_fButtletSpreed, m_fButtletSpreed) + transform.up * Random.Range(-0.1f, 0.1f) + transform.right * Random.Range(-0.1f, 0.1f), transform.rotation);
            _Poject.GetComponent<Rigidbody>().AddForce((_Poject.transform.forward * m_fProjSpeed)+FindObjectOfType<PlayerController>().GetComponent<Rigidbody>().velocity,ForceMode.Impulse);
            m_bCanAttack = false;
            m_fCoolDown = m_fAttackSpeed;
        }
    }
}
