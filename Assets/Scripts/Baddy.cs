using UnityEngine;

public class Baddy : Spaceship
{
    [SerializeField] private float m_waveSize = 0.01f;
    private float m_timer = 0;

    protected override Vector3 Move()
    {
        var movementVector = Vector3.zero;

        m_timer += Time.deltaTime;

        var y = Mathf.Sin(m_timer) * m_waveSize;

        movementVector.x = m_timer * GetMovementSpeed() * -1;
        movementVector.y = y;

        return movementVector;
    }
}
