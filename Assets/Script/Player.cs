using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Transform transform;
    private int score { get; set; }
    private int life { get; set; }
    private Vector3 spawnPosition = Vector3.zero;
    private const int INIT_SCORE = 0;
    private const int INIT_LIFE = 2;
    private const int SPEED = 3;

    private GameObject TerrainGenerator;

    // Start is called before the first frame update
    void Start()
    {
        transform = gameObject.GetComponent<Transform>();
        ResetLevel();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            transform.Translate(Vector3.forward * SPEED * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S) && global::TerrainGenerator.stopBack == false)
        {
          transform.Translate(Vector3.back * SPEED * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(Vector3.left * SPEED * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * SPEED * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.tag = "scoreObject";
        collision.gameObject.tag = "lifeObject";
        switch (collision.gameObject.tag)
        {
            case "scoreObject":
                score += 1;
                break;
            case "lifeObject":
                life += 1;
                break;
            case "car":
                if (CheckLife())
                {
                    life -= 1;
                    transform.Translate(spawnPosition);
                }
                else
                {
                    ResetLevel();
                }

                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "safeZone")
        {
            score += 1;
            spawnPosition = transform.position;
        }
        else if (other.gameObject.name == "endOfRun")
        {
            score += 2;
            SceneManager.LoadScene("Leve2");
        }
    }
    private bool CheckLife()
    {
        bool boolean;
        if (life > 1)
        {
            boolean = true;
        }
        else
        {
            boolean = false;
        }
        return boolean;
    }

    private void ResetLevel()
    {
        life = INIT_LIFE;
        score = INIT_SCORE;
        BackToSpawn();
    }
    private void BackToSpawn()
    {
        transform.Translate(spawnPosition);
    }
}
