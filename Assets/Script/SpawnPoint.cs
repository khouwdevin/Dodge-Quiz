using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField]
    public GameObject obstacle;

    float speed = 30f;
    float rotation = 10f;

    public static bool Isfirts = true;

    public GameObject clone_meteor;

    int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (!Isfirts)
        {
            clone_meteor = Instantiate(obstacle, transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        counter = 1;
        try
        {
            //clone_meteor.transform.Rotate(Vector3.forward * rotation * Time.deltaTime);
            clone_meteor.transform.Translate(Vector2.down * speed * Time.deltaTime);

            if (clone_meteor.transform.position.y < -51.7)
            {
                Destroy(clone_meteor);
            }
        }
        catch(Exception e)
        {

        }
    }
}
