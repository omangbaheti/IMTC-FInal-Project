using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinterPlayerPoints : MonoBehaviour
{

    private int playerPoints;
    [SerializeField] TextMeshProUGUI pointsText;
     
    // Start is called before the first frame update
    void Start()
    {
        playerPoints = 0;
    }

    public void UpdatePoints(int points)
    {
        playerPoints += points;
        pointsText.text = "Points:" + playerPoints;
    }
}
