using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static float timer;

    public static bool Isrunning;

    // Start is called before the first frame update
    void Start()
    {
        Isrunning = false;
        timer = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Isrunning)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Isrunning = false;
                Debug.Log("Time ups!");
            }
        }
    }

    public static void Clock(float add_time)
    {
        timer = add_time;
        Isrunning = true;
    }
}
