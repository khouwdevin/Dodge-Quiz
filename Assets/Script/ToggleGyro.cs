using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleGyro : MonoBehaviour
{
    [SerializeField]
    public Toggle gyro_toggle;

    private void Start()
    {
        if (MoveRocket.gyroenable)
        {
            gyro_toggle.isOn = true;
        }
        else
        {
            gyro_toggle.isOn = false;
        }
    }

    public void GyroEnable()
    {
        if (gyro_toggle.isOn)
        {
            MoveRocket.gyroenable = true;
        }
        else
        {
            MoveRocket.gyroenable = false;
        }
    }
}
