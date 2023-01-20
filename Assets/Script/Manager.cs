using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Manager : MonoBehaviour
{
    public static int level = 1;
    private GameObject camera;
    private GameObject player;
    public bool isTerrainLoaded;
    private float spawnTimeOffset;
    public TextMeshProUGUI pvText;
    public TextMeshProUGUI scoreText;
    void Start()
    {
        pvText = GameObject.Find("pv").GetComponent<TextMeshProUGUI>();
        scoreText = GameObject.Find("nb").GetComponent<TextMeshProUGUI>();
        camera = GameObject.Find("Main Camera");
        camera.transform.position = new Vector3(0, 7, 8.14f);
        camera.transform.rotation = Quaternion.Euler(90, 0, 0f);
        player= GameObject.Find("Player");
        spawnTimeOffset = Random.Range(1f, 2f);
        pvText.text = "2";
    }

    void Update()
    {
    }
    public void RunGame()
    {
        ThrowChicken();
        InvokeRepeating("ThrowChicken", 1.0f, spawnTimeOffset);
    }
    public void ThrowChicken()
    {
        GameObject[] roads = GameObject.FindGameObjectsWithTag("road");
        foreach (GameObject road in roads)
        {
            road.GetComponent<Road>().OpenTrafic();
        }
        spawnTimeOffset = Random.Range(1f, 2f);
    }

}
