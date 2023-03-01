using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    Regular,
    Boss
}

public class AttackWave
{
    public int m_numberOfBaddies;
    public float m_rateOfSpawn;
    public float m_waveSize = 0.01f;
    public float m_movementSpeed = 10;
    public float m_startingX = 0;
    public float m_startingY = 0;
    public EnemyType m_enemyType = EnemyType.Regular;
}


public class BaddySpawner : MonoBehaviour
{
    [SerializeField]
    private Baddy m_baddyPrefab;
    [SerializeField]
    private BigBoss m_bossPrefab;
    private List<AttackWave> m_attackWaves = new List<AttackWave>();
    private List<float> m_waveTimes = new List<float>();
    private float m_timer = 0;
    private int m_currentWave = 0;

    private void Start()
    {
        var attackWave = new AttackWave();
        attackWave.m_numberOfBaddies = 3;
        attackWave.m_rateOfSpawn = 0.5f;
        attackWave.m_startingY = 0;
        attackWave.m_startingX = 70;
        attackWave.m_waveSize = 10;
        attackWave.m_movementSpeed = 5;
        m_attackWaves.Add(attackWave);
        m_waveTimes.Add(3);

        attackWave = new AttackWave();
        attackWave.m_numberOfBaddies = 6;
        attackWave.m_rateOfSpawn = 0.8f;
        attackWave.m_startingY = 2;
        attackWave.m_startingX = 70;
        attackWave.m_waveSize = 15;
        attackWave.m_movementSpeed = 8;
        m_attackWaves.Add(attackWave);
        m_waveTimes.Add(9);

        attackWave = new AttackWave();
        attackWave.m_numberOfBaddies = 5;
        attackWave.m_rateOfSpawn = 0.4f;
        attackWave.m_startingY = 0;
        attackWave.m_startingX = 70;
        attackWave.m_waveSize = 25;
        attackWave.m_movementSpeed = 10;
        m_attackWaves.Add(attackWave);
        m_waveTimes.Add(15);

        attackWave = new AttackWave();
        attackWave.m_numberOfBaddies = 5;
        attackWave.m_rateOfSpawn = 0.5f;
        attackWave.m_startingY = 20;
        attackWave.m_startingX = 70;
        attackWave.m_waveSize = 30;
        attackWave.m_movementSpeed = 10;
        m_attackWaves.Add(attackWave);
        m_waveTimes.Add(18);

        attackWave = new AttackWave();
        attackWave.m_numberOfBaddies = 5;
        attackWave.m_rateOfSpawn = 1f;
        attackWave.m_startingY = -20;
        attackWave.m_startingX = 70;
        attackWave.m_waveSize = 30;
        attackWave.m_movementSpeed = 10;
        m_attackWaves.Add(attackWave);
        m_waveTimes.Add(25);

        attackWave = new AttackWave();
        attackWave.m_numberOfBaddies = 3;
        attackWave.m_rateOfSpawn = 0.25f;
        attackWave.m_startingY = 0;
        attackWave.m_startingX = 70;
        attackWave.m_waveSize = 5;
        attackWave.m_movementSpeed = 10;
        m_attackWaves.Add(attackWave);
        m_waveTimes.Add(30);

        attackWave = new AttackWave();
        attackWave.m_numberOfBaddies = 10;
        attackWave.m_rateOfSpawn = 0.75f;
        attackWave.m_startingY = 25;
        attackWave.m_startingX = 70;
        attackWave.m_waveSize = 50;
        attackWave.m_movementSpeed = 8;
        m_attackWaves.Add(attackWave);
        m_waveTimes.Add(36);

        attackWave = new AttackWave();
        attackWave.m_numberOfBaddies = 5;
        attackWave.m_rateOfSpawn = 0.5f;
        attackWave.m_startingY = 15;
        attackWave.m_startingX = 70;
        attackWave.m_waveSize = 30;
        attackWave.m_movementSpeed = 8;
        m_attackWaves.Add(attackWave);
        m_waveTimes.Add(45);

        attackWave = new AttackWave();
        attackWave.m_numberOfBaddies = 5;
        attackWave.m_rateOfSpawn = 0.5f;
        attackWave.m_startingY = -25;
        attackWave.m_startingX = 45;
        attackWave.m_waveSize = 30;
        attackWave.m_movementSpeed = 8;
        m_attackWaves.Add(attackWave);
        m_waveTimes.Add(46);

        attackWave = new AttackWave();
        attackWave.m_numberOfBaddies = 5;
        attackWave.m_rateOfSpawn = 1f;
        attackWave.m_startingY = -20;
        attackWave.m_startingX = 70;
        attackWave.m_waveSize = 30;
        attackWave.m_movementSpeed = 8;
        m_attackWaves.Add(attackWave);
        m_waveTimes.Add(50);

        attackWave = new AttackWave();
        attackWave.m_numberOfBaddies = 10;
        attackWave.m_rateOfSpawn = 0.5f;
        attackWave.m_startingY = 25;
        attackWave.m_startingX = 70;
        attackWave.m_waveSize = 15;
        attackWave.m_movementSpeed = 5;
        m_attackWaves.Add(attackWave);
        m_waveTimes.Add(60);

        attackWave = new AttackWave();
        attackWave.m_numberOfBaddies = 10;
        attackWave.m_rateOfSpawn = 1f;
        attackWave.m_startingY = 25;
        attackWave.m_startingX = 70;
        attackWave.m_waveSize = 25;
        attackWave.m_movementSpeed = 5;
        m_attackWaves.Add(attackWave);
        m_waveTimes.Add(70);

        attackWave = new AttackWave();
        attackWave.m_numberOfBaddies = 10;
        attackWave.m_rateOfSpawn = 1f;
        attackWave.m_startingY = 0;
        attackWave.m_startingX = 70;
        attackWave.m_waveSize = 25;
        attackWave.m_movementSpeed = 5;
        m_attackWaves.Add(attackWave);
        m_waveTimes.Add(71);

        attackWave = new AttackWave();
        attackWave.m_numberOfBaddies = 10;
        attackWave.m_rateOfSpawn = 1f;
        attackWave.m_startingY = -25;
        attackWave.m_startingX = 70;
        attackWave.m_waveSize = 25;
        attackWave.m_movementSpeed = 8;
        m_attackWaves.Add(attackWave);
        m_waveTimes.Add(72);

        attackWave = new AttackWave();
        attackWave.m_numberOfBaddies = 5;
        attackWave.m_rateOfSpawn = 0.4f;
        attackWave.m_startingY = 0;
        attackWave.m_startingX = 70;
        attackWave.m_waveSize = 25;
        attackWave.m_movementSpeed = 8;
        m_attackWaves.Add(attackWave);
        m_waveTimes.Add(80);

        attackWave = new AttackWave();
        attackWave.m_numberOfBaddies = 5;
        attackWave.m_rateOfSpawn = 0.5f;
        attackWave.m_startingY = 18;
        attackWave.m_startingX = 70;
        attackWave.m_waveSize = 30;
        attackWave.m_movementSpeed = 7;
        m_attackWaves.Add(attackWave);
        m_waveTimes.Add(85);

        attackWave = new AttackWave();
        attackWave.m_numberOfBaddies = 5;
        attackWave.m_rateOfSpawn = 1f;
        attackWave.m_startingY = -18;
        attackWave.m_startingX = 70;
        attackWave.m_waveSize = 30;
        attackWave.m_movementSpeed = 8;
        m_attackWaves.Add(attackWave);
        m_waveTimes.Add(95);

        attackWave = new AttackWave();
        attackWave.m_numberOfBaddies = 5;
        attackWave.m_rateOfSpawn = 0.5f;
        attackWave.m_startingY = -25;
        attackWave.m_startingX = 45;
        attackWave.m_waveSize = 30;
        attackWave.m_movementSpeed = 8;
        m_attackWaves.Add(attackWave);
        m_waveTimes.Add(96);

        attackWave = new AttackWave();
        attackWave.m_numberOfBaddies = 5;
        attackWave.m_rateOfSpawn = 0.5f;
        attackWave.m_startingY = 18;
        attackWave.m_startingX = 70;
        attackWave.m_waveSize = 30;
        attackWave.m_movementSpeed = 9;
        m_attackWaves.Add(attackWave);
        m_waveTimes.Add(100);

        attackWave = new AttackWave();
        attackWave.m_numberOfBaddies = 8;
        attackWave.m_rateOfSpawn = 0.75f;
        attackWave.m_startingY = 0;
        attackWave.m_startingX = 70;
        attackWave.m_waveSize = 30;
        attackWave.m_movementSpeed = 10;
        m_attackWaves.Add(attackWave);
        m_waveTimes.Add(110);

        attackWave = new AttackWave();
        attackWave.m_numberOfBaddies = 8;
        attackWave.m_rateOfSpawn = 2f;
        attackWave.m_startingY = 0;
        attackWave.m_startingX = 70;
        attackWave.m_waveSize = 10;
        attackWave.m_movementSpeed = 10;
        m_attackWaves.Add(attackWave);
        m_waveTimes.Add(111);

        attackWave = new AttackWave();
        attackWave.m_numberOfBaddies = 5;
        attackWave.m_rateOfSpawn = 0.5f;
        attackWave.m_startingY = -25;
        attackWave.m_startingX = 45;
        attackWave.m_waveSize = 30;
        attackWave.m_movementSpeed = 8;
        m_attackWaves.Add(attackWave);
        m_waveTimes.Add(112);


        attackWave = new AttackWave();
        attackWave.m_numberOfBaddies = 1;
        attackWave.m_rateOfSpawn = 1f;
        attackWave.m_startingY = 0;
        attackWave.m_startingX = 70;
        attackWave.m_movementSpeed = 10;
        attackWave.m_enemyType = EnemyType.Boss;
        m_attackWaves.Add(attackWave);
        m_waveTimes.Add(125);
    }

    private void Update()
    {
        m_timer += Time.deltaTime;

        if (m_waveTimes.Count > m_currentWave && m_timer > m_waveTimes[m_currentWave])
        {
            StartCoroutine(SpawnWave(m_attackWaves[m_currentWave]));
            m_currentWave++;
        }
    }

    IEnumerator SpawnWave(AttackWave _attackWave)
    {
        for (var i = 0; i < _attackWave.m_numberOfBaddies; i++)
        {
            if (_attackWave.m_enemyType == EnemyType.Boss)
            {
                Instantiate(m_bossPrefab, new Vector3(_attackWave.m_startingX, _attackWave.m_startingY, 50f), Quaternion.identity);
            }
            else
            {
                var go = Instantiate(m_baddyPrefab, new Vector3(_attackWave.m_startingX, _attackWave.m_startingY, 50f), Quaternion.identity).gameObject;
                var baddy = go.GetComponent<Baddy>();
                baddy.Spawn(_attackWave.m_waveSize, _attackWave.m_startingX, _attackWave.m_startingY, _attackWave.m_movementSpeed);
            }

            yield return new WaitForSeconds(_attackWave.m_rateOfSpawn);
        }
    }
}
