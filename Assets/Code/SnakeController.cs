using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SnakeController : MonoBehaviour {

    // Settings
    public float MoveSpeed = 5;
    public float MaxMoveSpeed = 30;
    public float MinMoveSpeed = 1;
    public float SteerSpeed = 180;
    public int Gap = 10;

    // References
    public GameObject BodyPrefab;
    public GameObject explosion;

    [SerializeField]
    private AudioSource backgroundMusic;
    [SerializeField]
    private AudioSource gameOverMusic;

    // Lists
    private List<GameObject> BodyParts = new List<GameObject>();
    private List<Vector3> PositionsHistory = new List<Vector3>();

    // Start is called before the first frame update
    void Start() {
        for (int i = 1; i< 20; i++)
        {
            GrowSnake();
        }
        backgroundMusic.Play();
    }

    // Update is called once per frame
    void Update() {

        // Move forward
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;

        // Steer
        float steerDirection = Input.GetAxis("Horizontal"); // Returns value -1, 0, or 1
        transform.Rotate(Vector3.up * steerDirection * SteerSpeed * Time.deltaTime);

        float accelerationDirection = Input.GetAxis("Vertical")/2; // Returns value -1, 0, or 1
        MoveSpeed = MoveSpeed + accelerationDirection;
        MoveSpeed = Mathf.Min(MoveSpeed, MaxMoveSpeed);
        MoveSpeed = Mathf.Max(MoveSpeed, MinMoveSpeed);

        //backgroundMusic.pitch = +0.1f;


    // Store position history
        PositionsHistory.Insert(0, transform.position);

        // Move body parts
        int index = 0;
        foreach (var body in BodyParts) {
            Vector3 point = PositionsHistory[Mathf.Clamp(index * Gap, 0, PositionsHistory.Count - 1)];

            // Move body towards the point along the snakes path
            Vector3 moveDirection = point - body.transform.position;
            body.transform.position += moveDirection * MoveSpeed * Time.deltaTime;

            // Rotate body towards the point along the snakes path
            body.transform.LookAt(point);

            index++;
        }
    }

    private void GrowSnake() {
        // Instantiate body instance and
        // add it to the list
        GameObject body = Instantiate(BodyPrefab);
        BodyParts.Add(body);
    }

    void OnCollisionEnter()
    {
        print("COLLISION!");
        GameObject expl = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
        backgroundMusic.Stop();
        gameOverMusic.Play();
        Destroy(gameObject); // destroy the grenade
    }
}
