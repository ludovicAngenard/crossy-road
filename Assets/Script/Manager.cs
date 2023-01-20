using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    //TODO
    // manage level 
    //manage player
    // manage score
    // manage spawns
    // manage bonus
    // manage endOfRun
    // manage limit of the map
    //manage camera
    public static int level;
    private GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] roads = GameObject.FindGameObjectsWithTag("road");
        foreach (GameObject road in roads) {
            road.GetComponent<Road>().OpenTrafic();
        }
        camera = GameObject.Find("Main Camera");
        camera.transform.position = new Vector3(0, 5, 10);
        camera.transform.rotation = new Vector3(0,-90, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
