using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{

    public float minVelo = 0.01f;

    private Vector3 lastMousePos;
    private Vector3 mouseVelo;
    private Rigidbody2D rb;
    private Collider2D col;
    

    void Awake()
    {
        rb=GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    void Update()
    {

        //col.enabled = isMouseMoving();
        SetBladeToMouse();    
    }

    private void SetBladeToMouse()
    {
        var mousePos=Input.mousePosition;
        mousePos.z = 10; //distance of 10 units from the camera

        rb.position = Camera.main.ScreenToWorldPoint(mousePos);

    }


    private bool isMouseMoving()
    {

        Vector3 curMousePos = transform.position;
        float travelled = (lastMousePos - curMousePos).magnitude;
        lastMousePos = curMousePos;

        if (travelled > minVelo)
            return true;

        else
            return false;


    }  
}
