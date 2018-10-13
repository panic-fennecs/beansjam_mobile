using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Button[] Buttons;
    private int LivePoints;

    public Text LiveText;

    private const int NUM_BUTTONS = 5;

    // Start is called before the first frame update
    void Start()
    {
        LivePoints = 3;
    }

    public void DecLivePoints()
    {
        LivePoints--;
        LiveText.text = LivePoints.ToString();
    }

    public int GetLivePoints()
    {
        return LivePoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
