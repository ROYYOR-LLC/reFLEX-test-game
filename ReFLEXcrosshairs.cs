using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReFLEXcrosshairs : MonoBehaviour
{
    public AudioSource gunshotsound;
    public int gunshotcount = 0;
    public GameObject gunshotcountdisplay;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;

        Vector3 mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
    }
    void Update()
    {
        gunshotcountdisplay.GetComponent<UnityEngine.UI.Text>().text = gunshotcount.ToString();
        if (Input.GetMouseButtonDown(0))
        {
            gunshotsound.Play();
            gunshotcount = gunshotcount + 1;
        }
    }
}
