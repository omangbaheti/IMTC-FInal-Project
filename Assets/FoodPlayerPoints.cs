using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FoodPlayerPoints : MonoBehaviour
{

    int playerPoints;
    [SerializeField] TextMeshProUGUI points;

    // Start is called before the first frame update
    void Start()
    {
        playerPoints = 0;
    }

    public void UpdatePoints(int foodPoints)
    {
        playerPoints += foodPoints;
        points.text = "Points: " + playerPoints;
    }
}
