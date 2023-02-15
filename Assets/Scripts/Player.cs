using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Player : Spaceship, IShooterable
{
    [SerializeField] private Bullet m_bulletPrefab;
    [SerializeField] private Transform m_bulletSpawnPoint;
    [SerializeField] private float m_timeBetweenShots = 0.5f;
    private float m_shotTimer = 0;

    private IObjectPool<Bullet> Pool;
    private const int c_maxPoolSize = 30;
    public IObjectPool<Bullet> BulletPool
    {
        get
        {
            if (Pool == null)
            {
                Pool = new ObjectPool<Bullet>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, true, c_maxPoolSize, c_maxPoolSize);
            }

            return Pool;
        }
    }

    private void OnDestroyPoolObject(Bullet obj)
    {
        Destroy(obj);
    }

    private void OnReturnedToPool(Bullet obj)
    {
        obj.gameObject.SetActive(false);
    }

    private void OnTakeFromPool(Bullet obj)
    {
        obj.gameObject.SetActive(true);
        obj.transform.position = m_bulletSpawnPoint.position;
        obj.transform.rotation = m_bulletSpawnPoint.rotation;
        obj.ShootBullet(this);
    }

    private Bullet CreatePooledItem()
    {
        var bullet = Instantiate(m_bulletPrefab);
        return bullet.GetComponent<Bullet>();
    }

    public void Shoot()
    {
        if (Input.GetButton("Fire1") && m_shotTimer > m_timeBetweenShots)
        {
            BulletPool.Get();
            m_shotTimer = 0;
        }

        m_shotTimer += Time.deltaTime;
    }

    public void ReturnBullet(Bullet _bullet)
    {
        BulletPool.Release(_bullet);
    }

    public string GetShooterName()
    {
        return this.name;
    }

    protected override Vector3 Move()
    {
        var movementVector = Vector3.zero;

        var horitonzalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");

        movementVector.x = horitonzalInput * GetMovementSpeed() * Time.deltaTime;
        movementVector.y = verticalInput * GetMovementSpeed() * Time.deltaTime;

        return movementVector;
    }
}
