using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public int points = 10;
    public GameObject crosshairs;
    
    void OnMouseDown()
    {
        crosshairs = GameObject.Find("crosshairs");
        crosshairs.GetComponent<hittarget>().addscore(points);
        Destroy(gameObject);
    }
}
