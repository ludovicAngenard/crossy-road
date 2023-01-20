using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Chicken : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 endPosition;
    public float speed;

    void Start()
    {
        transform.rotation = Quaternion.Euler(0, -90, 0f);
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

