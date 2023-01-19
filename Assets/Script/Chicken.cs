using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    // Start is called before the first frame update
    {
    public Vector3 startPosition;
    public Vector3 endPosition;
    private float speed;

    void Start()
    {
        float = Random.Range(1.5f, 3f);
        transform.position = startPosition;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);
        if (transform.position == endPosition)
        {
            Destroy(gameObject);
        }
    }
}

