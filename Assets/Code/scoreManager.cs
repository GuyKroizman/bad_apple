using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class scoreManager : MonoBehaviour
{

    private float lastUpdate;
    private int score;
    private bool isRunning;

    // Start is called before the first frame update
    void Start()
    {
        lastUpdate = Time.time;
        gameStart();
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning) //  (Time.time - lastUpdate >= 1f)
        {
            score += 1;
            this.GetComponent<UnityEngine.UI.Text>().text = score.ToString();
            lastUpdate = Time.time;
        }
    }

    public void gameOver()
    {
        this.isRunning = false;
    }

    public void gameStart()
    {
        this.isRunning = true;
    }
}
