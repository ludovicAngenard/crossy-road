using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Transform transform;
    private int score { get; set; }
    private int life { get; set; }
    private Vector3 spawnPosition = new Vector3(0,0.75f,6f);
    private const int INIT_SCORE = 0;
    private const int INIT_LIFE = 2;
    private const int SPEED = 3;
    public bool dead = false;
    private Manager manager;
    private GameObject TerrainGenerator;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("Manager").GetComponent<Manager>();
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

        if (Input.GetKey(KeyCode.S) && TerrainsGenerator.stopBack == false)
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

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "safeZone":
                if (!Input.GetKey(KeyCode.S)) 
                {
                    score += 1;
                    manager.scoreText.text = score.ToString();
                    spawnPosition = new Vector3(transform.position.x, transform.position.y, other.gameObject.transform.position.z);
                }
                break;
            case "scoreObject":
                score += 1;
                manager.scoreText.text = score.ToString();
                break;
            case "lifeObject":
                life += 1;
                manager.pvText.text = life.ToString();
                break;
            case "Chicken":
                if (CheckLife())
                {
                    life -= 1;
                    score -= 1;
                    manager.pvText.text = life.ToString();
                    transform.position = spawnPosition;
                }
                else
                {
                    SceneManager.LoadScene("Menu");
                    dead = true;
                    //HighScores.instance.SaveScore("##TODO_PSEUDO", score);
                }
                break;
        }
    }
    private bool CheckLife()
    {
        bool boolean;
        if (life > 1) boolean = true;
        else boolean = false;
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
        transform.position = spawnPosition;
    }
}
