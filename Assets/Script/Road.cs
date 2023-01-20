

using UnityEngine;

public class Road : MonoBehaviour
{
    private float speedLimit;
    private Vector3 spawnPosition;
    private Vector3 endPosition;
    public  GameObject chicken;
    // Start is called before the first frame update
    void Start()
    {
        FindSpeedLimit(Manager.level);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FindSpeedLimit(int level)
    {
        switch (level)
        {
            case 1:
                speedLimit = Random.Range(3f, 5f);
                break;
            case 2:
                speedLimit = Random.Range(5f, 7f);
                break;
            case 3:
                speedLimit = Random.Range(7f, 9f);
                break;
        }
        chicken.GetComponent<Chicken>().speed = speedLimit;
    }

    public void OpenTrafic()
    {
        endPosition = FindClosestObjectByTag("end").transform.position;
        spawnPosition = FindClosestObjectByTag("spawn").transform.position;

        chicken = Instantiate(chicken, spawnPosition, Quaternion.identity);
        chicken.GetComponent<Chicken>().endPosition = endPosition;
    }


    public GameObject FindClosestObjectByTag(string tag)
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag(tag);
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}
