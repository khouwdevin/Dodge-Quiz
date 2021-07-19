using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField]
    public float lifetime = 2;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
