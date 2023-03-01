using UnityEngine;

public class Baddy : Spaceship
{
    [SerializeField] private float m_waveSize = 0.01f;
    [SerializeField] private float m_startingX = 0;
    [SerializeField] private float m_startingY = 0;
    private float m_timer = 0;

    public void Spawn(float _waveSize, float _startingX, float _startingY, float _speed)
    {
        m_waveSize = _waveSize;
        m_startingX = _startingX;
        m_startingY = _startingY;
        SetMovementSpeed(_speed);
    }

    protected override Vector3 Move()
    {
        var movementVector = Vector3.zero;

        m_timer += Time.deltaTime * GetMovementSpeed();

        var y = Mathf.Sin(m_timer) * m_waveSize;

        movementVector.x = m_timer * -1;
        movementVector.y = y;

        movementVector.y -= transform.position.y - m_startingY;
        movementVector.x -= transform.position.x - m_startingX;

        return movementVector;
    }
}
