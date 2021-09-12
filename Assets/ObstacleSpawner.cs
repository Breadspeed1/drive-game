using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    public float xMin = -2;
    public float xMax = 2;
    public float zMin = -14;
    public float zMax = 8;

    public List<GameObject> spawnableObstacles = new List<GameObject>();
    public List<GameObject> spawnedObstacles = new List<GameObject>();

    public GameObject obstacleParent;

    public void spawnObstacles()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject gj = Instantiate(spawnableObstacles[Random.Range(0, spawnableObstacles.Count)], this.transform);
            Vector3 pos = new Vector3(Convert.ToSingle(Math.Round(Random.Range(xMin, xMax), 0)), 0, Convert.ToSingle(Math.Round(Random.Range(zMin, zMax), 0)));
            if (pos.x % 2 != 0)
            {
                if (pos.x ! <= xMax)
                {
                    pos.x += 1;
                }
                else
                {
                    pos.x -= 1;
                }
            }

            if (pos.z % 2 != 0)
            {
                if (pos.z ! <= zMax)
                {
                    pos.z += 1;
                }
                else
                {
                    pos.z -= 1;
                }
            }
            
            //Debug.Log(pos);
            
            gj.transform.localScale = new Vector3(50, 50, 50);
            gj.transform.localRotation = Quaternion.Euler(-90, 180, 0);
            gj.transform.localPosition = pos;
        }
    }
}
