using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript : MonoBehaviour
{
    public static ManagerScript Instance;

    public int mahimahi = 0;
    public int salmon = 0;
    public int tilapia = 0;
    public int mahimahiSold = 0;
    public int salmonSold = 0;
    public int tilapiaSold = 0;

    public bool activeSellButton = false;

    public int timesTalkedToGordon = 0;
    public int timesTalkedToTaqueriaChef = 0;
    public int timeTalkedToSushiChef = 0;

    public bool hasEnteredDock = false;

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
