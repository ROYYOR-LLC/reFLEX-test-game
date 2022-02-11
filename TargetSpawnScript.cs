using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawnScript : MonoBehaviour
{
    public Transform lowerbound;
    public Transform upperbound;
    private int roundcounter;
    private float cooldowntime = 3f;
    private float nextfiretime;
    private Vector3 targetboardspawnpoint;
    public GameObject TargetBoard;
    private float nextRoundtime;
    private float targetboardxposition;
    private float targetboardyposition;
    private float xpositionswap;
    private float ypositionswap;
    public int roundnumber = 0;
    public GameObject rounddisplay;
    public GameObject GameOver;
    public float height;
    public float width;


    // Start is called before the first frame update
    void Start()
    {
        Camera cam = Camera.main;
        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;
        GameOver.SetActive(false);
        xpositionswap = cam.transform.position.x;
        ypositionswap = cam.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        rounddisplay.GetComponent<UnityEngine.UI.Text>().text = roundnumber.ToString();
        if (roundnumber < 18)
        {
            if (Time.time > nextRoundtime)
            {
                if (cooldowntime > 0.2f)
                {
                    cooldowntime = cooldowntime - 0.2f;
                }
                nextRoundtime = Time.time + 15f;
                roundnumber = roundnumber + 1;
            }
            if (Time.time > nextfiretime)
            {
                
                targetboardxposition = Random.Range(xpositionswap - (width / 4), xpositionswap + (width / 4));
                targetboardyposition = Random.Range(ypositionswap - (height / 3), ypositionswap + (height / 3));
                //targetboardxposition = Random.Range(lowerbound.position.x, upperbound.position.x);
                //targetboardyposition = Random.Range(lowerbound.position.y, upperbound.position.y);
                targetboardspawnpoint.Set(targetboardxposition, targetboardyposition, 0f);
                GameObject clone = (GameObject)Instantiate(TargetBoard, targetboardspawnpoint, Quaternion.identity);
                if (clone != null)
                {
                    Destroy(clone, cooldowntime);
                }
                nextfiretime = Time.time + cooldowntime;
            }
        }

        if (roundnumber == 17)
        {
            GameOver.SetActive(true);
            Time.timeScale = 0f;
            AudioListener.pause = true;
            Cursor.visible = true;
        }
    }
}
