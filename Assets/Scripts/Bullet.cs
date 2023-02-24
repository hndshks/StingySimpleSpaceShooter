using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float m_bulletSpeed = 10f;
    [SerializeField] private AudioSource m_bulletShootSound;
    [SerializeField] private float m_bulletLifeTime = 3f;
    [SerializeField] private int m_bulletDamage = 100;
    private IShooterable m_shooter;
    private float m_timer = 0;
    private bool m_isActive = false;

    public void ShootBullet(IShooterable _shooter)
    {
        m_isActive = true;
        m_timer = 0;
        m_bulletShootSound.Play();
        m_shooter = _shooter;
    }

    private void FixedUpdate()
    {
        if (m_isActive)
        {
            m_timer += Time.deltaTime;
            if (m_timer > m_bulletLifeTime)
            {
                m_isActive = false;
                m_shooter.ReturnBullet(this);
            }

            transform.position += transform.forward * m_bulletSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != m_shooter.GetShooterName())
        {
            if (other.gameObject.GetComponent<Spaceship>() != null)
            {
                other.gameObject.GetComponent<Spaceship>().TakeDamage(m_bulletDamage);
                m_isActive = false;
                m_shooter.ReturnBullet(this);
            }
        }
    }
}
