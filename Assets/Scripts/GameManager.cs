using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public EnemyWave[] enemyWaves;

    private int enemiesDestroyed;

    public int currentLevel = 0;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        LoadLevel(currentLevel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemy() {
        Vector3 direction = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
        GameObject enemy = Instantiate(enemyWaves[currentLevel].enemyPrefab, transform.position + direction.normalized * enemyWaves[currentLevel].distanceToSpawn, Quaternion.identity);
    }

    public void TargetDestroyed() {
        enemiesDestroyed++;
        if(enemiesDestroyed >= enemyWaves[currentLevel].enemiesToDestroy) {
            enemiesDestroyed = 0;
            currentLevel++;
            if (currentLevel >= enemyWaves.Length)
                EndGame();
            LoadLevel(currentLevel);
        }
        else {
            SpawnEnemy();
        }
    }

    public void LoadLevel(int lvl) {
        SoundManager.Instance.PlayDemonLaugh();
        SpawnEnemy();
    }

    public void EndGame() {
        Destroy(gameObject);
    }
}

[System.Serializable]
public class EnemyWave {
    public GameObject enemyPrefab;
    public int enemiesToDestroy;
    public float distanceToSpawn;
}
