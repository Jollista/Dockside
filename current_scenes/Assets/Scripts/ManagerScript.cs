using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript : MonoBehaviour
{
    public static ManagerScript Instance;

    public FishingarrowController fishingArrowScript;
    public FishCaughtDisplayBehaviour fishDisplayScript;

    public GameObject fishCaughtDisplay;

    public string fishName = "";

    public int successGrey = 0;
    public int successRed = 0;
    public int successYellow = 0;
    public int successGreen = 0;
    public int success = 0;

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

    public void catchSuccess(string successColor)
    {
        success = Random.Range(0, 101);

        switch (successColor)
        {
            case "Grey":
                success += successGrey;
                break;
            case "Red":
                success += successRed;
                break;
            case "Yellow":
                success += successYellow;
                break;
            case "Green":
                success += successGreen;
                break;
        }

        if(success >= 90)
        {
            catchFish(true);
        }
        else
        {
            catchFish(false);
        }
    }

    void catchFish(bool isSuccess)
    {
        if (isSuccess)
        {
            int fishType = Random.Range(1, 4);

            switch (fishType)
            {
                case 1:
                    mahimahi++;
                    fishName = "a Mahi-Mahi!";
                    break;
                case 2:
                    salmon++;
                    fishName = "a Salmon!";
                    break;
                case 3:
                    tilapia++;
                    fishName = "a Tilapia!";
                    break;
            }
        }

        else
        {
            fishName = "nothing.";
        }

        fishCaughtDisplay.SetActive(true);
        fishDisplayScript.displayCatchInfo();
    }
}
