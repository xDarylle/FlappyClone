using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstacle;
    public float spawnTime;

    public Player player;

    float timer = 0;
    // Update is called once per frame
    void Update()
    {
        if(player.start)
        {
            timer += Time.deltaTime;

            if (timer >= spawnTime)
            {
                Vector3 pos = new Vector3(6, Random.Range(-2f, 2f), 0);

                Instantiate(obstacle, pos, Quaternion.identity);
                timer = 0;
            }
        }
    }
}
