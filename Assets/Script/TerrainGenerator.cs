using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TerrainGenerator : MonoBehaviour
{
  [SerializeField] private int maxTerrainCount;
  [SerializeField] private List<GameObject> terrains = new List<GameObject>();

  [SerializeField] private GameObject grassTerrain;
  [SerializeField] private GameObject roadTerrain;

  private List<GameObject> currentTerrains = new List<GameObject>();
  private Vector3 currentPosition = new Vector3(0, 0, 0);

  private void Start()
  {
    for (int i = 0; i < maxTerrainCount; i++)
    {
      SpawnTerrain();
    }
  }

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Z))
    {
      SpawnTerrain();
    }
  }

  private void SpawnTerrain()
  {
    for (int i = 0; i < terrains.Count; i++)
    {
      GameObject terrain = Instantiate(terrains[i], currentPosition, Quaternion.identity);
      currentTerrains.Add(terrain);
      currentPosition.x++;
    }

    /*if (currentTerrains.Count > maxTerrainCount)
    {
      Destroy(currentTerrains[0]);
      currentTerrains.RemoveAt(0);
    }*/
    //currentPosition.x++;
  }
}
