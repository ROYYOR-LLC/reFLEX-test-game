using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hittarget : MonoBehaviour
{
    public int score = 0;
    public GameObject tgspawnscript;
    public int rounds;
    public GameObject ScoreDisplay;

    public void addscore(int points)
    {
        score = score + (rounds * points);
    }

    void Update()
    {
       
        ScoreDisplay.GetComponent<UnityEngine.UI.Text>().text = score.ToString();
        rounds = tgspawnscript.GetComponent<TargetSpawnScript>().roundnumber;
    }
}
