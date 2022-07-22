using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class scoreManager : MonoBehaviour
{

    private float lastUpdate;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        lastUpdate = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (true) //  (Time.time - lastUpdate >= 1f)
        {
            score += 1;
            this.GetComponent<UnityEngine.UI.Text>().text = score.ToString();
            lastUpdate = Time.time;
        }
    }
}
