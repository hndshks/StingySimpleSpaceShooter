using UnityEngine;
using UnityEngine.Rendering;

public enum SpaceshipType
{
    Player,
    Enemy
}

public class Spaceship : MonoBehaviour
{
    [SerializeField] private int m_maxHealth = 100;
    [SerializeField] private float m_moveSpeed = 10f;
    [SerializeField] private bool m_canMoveBeyondBounds = false;
    [SerializeField] private int m_collisionDamage = 100;
    [SerializeField] private AudioSource m_explodeSound;
    [SerializeField] private ParticleSystem m_explodeParticles;
    [SerializeField] private GameObject m_meshGameObject;
    [SerializeField] private SpaceshipType m_spaceshipType;

    private int m_currentHealth = 100;
    private bool m_isAlive = true;

    private const float c_yRotationValue = 90f;
    private const float c_pitchUpValue = -15;
    private const float c_pitchDownValue = 15;
    private const float c_pitchSpeed = 3f;

    private void Awake()
    {
        m_currentHealth = m_maxHealth;
        m_isAlive = true;
    }

    private void FixedUpdate()
    {
        if (m_isAlive)
        {
            var movementVector = Move();

            if (movementVector.y > 0)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(c_pitchUpValue, c_yRotationValue, 0), c_pitchSpeed * Time.deltaTime);
            }
            else if (movementVector.y < 0)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(c_pitchDownValue, c_yRotationValue, 0), c_pitchSpeed * Time.deltaTime);
            }
            else
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, c_yRotationValue, 0), c_pitchSpeed * Time.deltaTime);
            }
            
            var oldPosition = transform.position;
            transform.position += movementVector;

            if (!m_canMoveBeyondBounds)
            {
                var screenCoordinates = Camera.main.WorldToScreenPoint(transform.position);
                if (screenCoordinates.x < 0)
                {
                    transform.position = new Vector3(oldPosition.x, transform.position.y, transform.position.z);
                }
                else if (screenCoordinates.x > Screen.width)
                {
                    transform.position = new Vector3(oldPosition.x, transform.position.y, transform.position.z);
                }

                if (screenCoordinates.y < 0)
                {
                    transform.position = new Vector3(transform.position.x, oldPosition.y, transform.position.z);
                }
                else if (screenCoordinates.y > Screen.height)
                {
                    transform.position = new Vector3(transform.position.x, oldPosition.y, transform.position.z);
                }
            }

            if (gameObject.GetComponent<IShooterable>() != null)
            {
                gameObject.GetComponent<IShooterable>().Shoot();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Spaceship>().GetSpaceshipType() != GetSpaceshipType())
        {
            TakeDamage(m_collisionDamage);
        }
    }

    protected virtual Vector3 Move()
    {
        return Vector3.zero;
    }

    public SpaceshipType GetSpaceshipType()
    {
        return m_spaceshipType;
    }

    public void TakeDamage(int _damage)
    {
        m_currentHealth -= _damage;
        if (m_currentHealth <= 0 && m_isAlive)
        {
            m_isAlive = false;
            Die();
        }
    }

    private void Die()
    {
        if (!m_isAlive)
        {
            m_explodeSound.Play();
            m_explodeParticles.Play();
            m_meshGameObject.SetActive(false);

            if (gameObject.GetComponent<BoxCollider>() != null)
            {
                gameObject.GetComponent<BoxCollider>().enabled = false;
            }
        }
    }

    public float GetMovementSpeed()
    {
        return m_moveSpeed;
    }

    public void SetMovementSpeed(float _speed)
    {
        m_moveSpeed = _speed;
    }
}
