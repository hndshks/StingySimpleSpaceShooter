using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Rendering;

public class BigBoss : Spaceship, IShooterable
{
    [SerializeField] private Vector3 m_finalPositionLeft;
    [SerializeField] private Vector3 m_finalPositionRight;
    [SerializeField] private Bullet m_bulletPrefab;
    [SerializeField] private Transform m_bulletSpawnPoint;
    [SerializeField] private float m_timeBetweenShots = 0.5f;

    private GameObject m_player;
    private bool m_goingLeft = true;
    private float m_shotTimer = 0;
    private IObjectPool<Bullet> Pool;
    private const int c_maxPoolSize = 30;
    private const float c_distanceThreshhold = 0.5f;

    protected override Vector3 Move()
    {
        var movementVector = Vector3.zero;

        // Travel to the left position, then when we get there, start traveling right...
        if (m_goingLeft)
        {
            movementVector.x = GetMovementSpeed() * Time.deltaTime * -1;
            if (Vector3.Distance(transform.position, m_finalPositionLeft) <= c_distanceThreshhold)
            {
                m_goingLeft = false;
            }
        }
        else
        {
            movementVector.x = GetMovementSpeed() * Time.deltaTime;
            if (Vector3.Distance(transform.position, m_finalPositionRight) <= c_distanceThreshhold)
            {
                m_goingLeft = true;
            }
        }

        return movementVector;
    }

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
        if (m_player == null)
        {
            GetPlayer();
        }

        obj.gameObject.SetActive(true);
        obj.transform.position = m_bulletSpawnPoint.position;
        // rotate the bullet to look towards the current player position...
        obj.transform.LookAt(m_player.transform);
        obj.ShootBullet(this);
    }

    private Bullet CreatePooledItem()
    {
        var bullet = Instantiate(m_bulletPrefab);
        return bullet.GetComponent<Bullet>();
    }

    public void Shoot()
    {
        if (m_shotTimer > m_timeBetweenShots)
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
        return name;
    }

    private void GetPlayer()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");
    }
}
