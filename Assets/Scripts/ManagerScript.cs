using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript : MonoBehaviour
{
    public static ManagerScript Instance;

    public int mahimahi = 0;
    public int salmon = 0;
    public int tilapia = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
