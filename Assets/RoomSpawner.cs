using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoomSpawner : MonoBehaviour
{
    public GameObject player;
    public GameObject environment;
    public List<GameObject> spawnableRooms = new List<GameObject>();
    public List<GameObject> spawnedRooms = new List<GameObject>();
    private bool needToChangeRooms = false;
    public float moveSpeed;
    
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            switch (i)
            {
                case 0:
                    GameObject gj1 = Instantiate(spawnableRooms[Random.Range(0, spawnableRooms.Count)], new Vector3(0, 0, 9.4f), quaternion.identity, environment.transform);
                    //gj1.GetComponent<ObstacleSpawner>().spawnObstacles();
                    spawnedRooms.Add(gj1);
                    break;
                case 1:
                    GameObject gj2 = Instantiate(spawnableRooms[Random.Range(0, spawnableRooms.Count)], spawnedRooms[0].transform.localPosition + new Vector3(0, 0, 24), quaternion.identity, environment.transform);
                    gj2.GetComponent<ObstacleSpawner>().spawnObstacles();
                    spawnedRooms.Add(gj2);
                    break;
                case 2:
                    GameObject gj3 = Instantiate(spawnableRooms[Random.Range(0, spawnableRooms.Count)], spawnedRooms[1].transform.localPosition + new Vector3(0, 0, 24), quaternion.identity, environment.transform);
                    gj3.GetComponent<ObstacleSpawner>().spawnObstacles();
                    spawnedRooms.Add(gj3);
                    break;
            }
        }
    }

    private void Update()
    {
        if (needToChangeRooms)
        {
            Destroy(spawnedRooms[0]);
            spawnedRooms.RemoveAt(0);
            GameObject gj = Instantiate(spawnableRooms[Random.Range(0, spawnableRooms.Count)], spawnedRooms[1].transform.localPosition + new Vector3(0, 0, 24), quaternion.identity, environment.transform);
            gj.GetComponent<ObstacleSpawner>().spawnObstacles();
            spawnedRooms.Add(gj);
            needToChangeRooms = false;
        }

        foreach(GameObject room in spawnedRooms)
        {
            //Debug.Log(room.transform.localPosition);
            //room.transform.Translate(room.transform.localPosition - new Vector3(0, 0, 0.000001f * Time.deltaTime));
            room.transform.localPosition -= new Vector3(0, 0, moveSpeed * Time.deltaTime);
        }

        if (spawnedRooms[0].transform.position.z <= -29.4)
        {
            needToChangeRooms = true;
        }
    }
}
