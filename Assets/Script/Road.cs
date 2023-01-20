using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    private float speedLimit;
    private Vector3 spawnPosition;
    private Vector3 endPosition;
    private GameObject chicken;
    // Start is called before the first frame update
    void Start()
    {
        chicken = Resources.Load<GameObject>("/Assets/Prefabs/chicken");
        FindSpeedLimit(Manager.level);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FindSpeedLimit(int level)
    {
        switch (level)
        {
            case 1:
                speedLimit = Random.Range(1.5f, 3f);
                break;
            case 2:
                speedLimit = Random.Range(3f, 4.5f);
                break;
            case 3:
                speedLimit = Random.Range(4.5f, 6f);
                break;
        }
    }

    public void OpenTrafic()
    {
        spawnPosition = transform.Find("Spawn").transform.position;
        endPosition = transform.Find("End").transform.position;
        chicken = GameObject.Instantiate(chicken, spawnPosition, Quaternion.identity);
    }
}
