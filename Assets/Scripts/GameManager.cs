using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool m_playerWon = false;
    private bool m_playerLost = false;
    private float m_timer = 0;
    private const float c_timer = 3;
    
    public static GameManager Instance { get; private set; }
    
    public void OnBossDied()
    {
        m_playerWon = true;
    }

    public void OnPlayerDied()
    {
        m_playerLost = true;
    }
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (m_playerWon)
        {
            m_timer += Time.deltaTime;
            if (m_timer > c_timer)
            {
                m_timer = 0;
                m_playerWon = false;
                UnityEngine.SceneManagement.SceneManager.LoadScene("Won");
            }
        }

        if (m_playerLost)
        {
            m_timer += Time.deltaTime;
            if (m_timer > c_timer)
            {
                m_timer = 0;
                m_playerWon = false;
                UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
            }
        }
    }
}
