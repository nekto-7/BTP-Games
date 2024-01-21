using System.Collections;
using UnityEditor.UIElements;
using UnityEngine;

public class SimpleEnemySpowner : soundctl
{
    public EnemyController enemyToSpawn;

    public Transform spawnPoint;

    public float timeBetweenSpawns;
    private float spawnCounter;

    public int amountToSpawn = 15;

    public Castle theCastle;
    public Path thePath;
    public bool flag;
    void Start()
    {
        spawnCounter = timeBetweenSpawns;
        if(flag)
        {
            Instantiate(enemyToSpawn, spawnPoint.position, spawnPoint.rotation).Setup(theCastle, thePath);

        }
        amountToSpawn--;
    }

    void Update()
    {
        if (amountToSpawn > 0)
        {
            spawnCounter -= Time.deltaTime;
            if (spawnCounter <= 0)
            {
                spawnCounter = timeBetweenSpawns;
                if (sounds != null && sounds.Length > 0)
                {
                    PlaySound(sounds[0]);
                }
                Instantiate(enemyToSpawn, spawnPoint.position, spawnPoint.rotation).Setup(theCastle, thePath);
                amountToSpawn--;
            }
        }


    }
}

