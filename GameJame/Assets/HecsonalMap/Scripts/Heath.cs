using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heath : MonoBehaviour
{
    public static int heath;
    public GameObject Heart1, Heart2, Heart3;
    // Start is called before the first frame update
    void Start()
    {
        Heart1.SetActive(true);
        Heart1.SetActive(true);
        Heart1.SetActive(true);
        heath = 3;
    }

    // Update is called once per frame
    void Update()
    {
        switch(heath)
        {
            case 3:
                Heart1.SetActive(true);
                Heart2.SetActive(true);
                Heart3.SetActive(true);
                break;
            case 2:
                Heart1.SetActive(true);
                Heart2.SetActive(true);
                Heart3.SetActive(false);
                break;
            case 1:
                Heart1.SetActive(true);
                Heart2.SetActive(false);
                Heart3.SetActive(false);
                break;
            case 0:
                Heart1.SetActive(false);
                Heart2.SetActive(false);
                Heart3.SetActive(false);
                break;
        }
    }
}
