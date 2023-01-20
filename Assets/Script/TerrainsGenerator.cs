using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TerrainsGenerator : MonoBehaviour
{
  private int maxTerrainCount = 10;
  [SerializeField] private List<GameObject> terrains = new List<GameObject>();


  private List<GameObject> currentTerrains = new List<GameObject>();
  private Vector3 currentPosition = new Vector3(0, 0, 0);

  private GameObject Player;
  public static bool stopBack = false;
  public static bool isGenerated = false;
  private Manager manager;

  private void Start()
  {
    manager = GameObject.Find("Manager").GetComponent<Manager>();
    Player = GameObject.Find("Player");
    for (int i = 0; i < maxTerrainCount; i++)
    {
      SpawnTerrain();
    }
    manager.RunGame();
    }

  private void Update()
  {
    float dist = currentTerrains[currentTerrains.Count - 1].transform.position.z - Player.transform.position.z;
    float distAr = Player.transform.position.z - currentTerrains[0].transform.position.z;

    if (dist <= 9)
    {
      SpawnTerrain();
    }

    if (distAr <= 0)
    {
      stopBack = true;
    }
    else
    {
      stopBack = false;
    }
  }

  private void SpawnTerrain()
  {
    for (int i = 0; i < terrains.Count; i++)
    {
      GameObject terrain = Instantiate(terrains[i], currentPosition, Quaternion.identity);
      currentTerrains.Add(terrain);
      currentPosition.z++;
    }

    if (currentTerrains.Count > maxTerrainCount)
    {
      Destroy(currentTerrains[0]);
      currentTerrains.RemoveAt(0);
    }
  }
}
