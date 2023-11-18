using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{
    public GameObject obj, player;
    private bool click0 = false, click1 = false, click2 = false, click3 = false, click4 = false, click5 = false, goClick = false, goClick0 = false, goClick1 = false, goClick2 = false, goClick3 = false, goClick4 = false, goClick5 = false;
    private Vector2 pos1, pos2, pos3, pos4, pos5, pos6;
    GameObject cloneobj1, cloneobj2, cloneobj3;
    public float distance, followSpeed, loopSpeed;
    private void Start()
    {
   
    }
    private void Update()
    {
        MainMechanic();
        if(!goClick)
        {
            Follow();
        }
        
    }
    void Loop(Vector2 pos1, Vector2 pos2, GameObject obj, bool destroy)
    {
        obj.transform.position = Vector2.Lerp(obj.transform.position, pos2, Time.deltaTime * loopSpeed);
        if (((int)obj.transform.position.x) == ((int)pos2.x) && ((int)obj.transform.position.y) == ((int)pos2.y) && destroy)
        {
            Destroy(obj);
        }
    }
    Vector2 MousePos()
    {
        Vector2 mousePositionScreen, mousePositionWorld = new Vector2(0, 0);
        mousePositionScreen = Input.mousePosition;
        mousePositionWorld = Camera.main.ScreenToWorldPoint(mousePositionScreen);

        Ray2D ray = new Ray2D(mousePositionWorld, Vector2.zero);
        RaycastHit2D hit;
        hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit.collider != null && hit.collider.CompareTag("Area"))
        {         
            return mousePositionWorld;
        }
        else
        {
            return new Vector2(0,0);
        }
    }
    void MainMechanic()
    {
        if (Input.GetMouseButtonDown(0) && !click0 && MousePos() != new Vector2(0, 0))
        {
            pos1 = MousePos();
            goClick0 = true;
            goClick = true;
        }
        if (goClick0)
        {
            Loop(transform.position, pos1, this.gameObject, false);
            if (((int)transform.position.x) == ((int)pos1.x) && ((int)transform.position.y) == ((int)pos1.y))
            {
                click0 = true;
                goClick0 = false;
                goClick = false;
            }
        }
        if (Input.GetMouseButtonDown(1) && click0 && !click1 && MousePos() != new Vector2(0, 0))
        {
            pos2 = MousePos();           
            goClick1 = true;
            goClick = true;
            
        }
        if (goClick1)
        {
            Loop(transform.position, pos2, this.gameObject, false);
            if (((int)transform.position.x) == ((int)pos2.x) && ((int)transform.position.y) == ((int)pos2.y))
            {
                click1 = true;
                goClick1 = false;
                goClick = false;
            }
        }
        if (click0 && click1)
        {
            if (cloneobj1 == null)
            {
                cloneobj1 = Instantiate(obj, pos1, Quaternion.identity);
            }
            else
            {
                Loop(pos1, pos2, cloneobj1, true);
            }
        }
        if (Input.GetMouseButtonDown(0) && click1 && !click2 && MousePos() != new Vector2(0, 0))
        {
            pos3 = MousePos();
            goClick = true;
            goClick2 = true;
            
        }
        if (goClick2)
        {
            Loop(transform.position, pos3, this.gameObject, false);
            if (((int)transform.position.x) == ((int)pos3.x) && ((int)transform.position.y) == ((int)pos3.y))
            {
                click2 = true;
                goClick2 = false;
                goClick = false;
            }
        }
        if (Input.GetMouseButtonDown(1) && click2 && !click3 && MousePos() != new Vector2(0, 0))
        {
            pos4 = MousePos();
            goClick = true;
            goClick3 = true;
            
           
        }
        if (goClick3)
        {
            Loop(transform.position, pos4, this.gameObject, false);
            if (((int)transform.position.x) == ((int)pos4.x) && ((int)transform.position.y) == ((int)pos4.y))
            {
                click3 = true;
                goClick3 = false;
                goClick = false;
            }
        }
        if (click2 && click3)
        {
            if (cloneobj2 == null)
            {
                cloneobj2 = Instantiate(obj, pos3, Quaternion.identity);
            }
            else
            {
                Loop(pos3, pos4, cloneobj2, true);
            }
        }
        if (Input.GetMouseButtonDown(0) && click3 && !click4 && MousePos() != new Vector2(0, 0))
        {
            pos5 = MousePos();
            goClick = true;
            goClick4 = true;
            
        }
        if (goClick4)
        {
            Loop(transform.position, pos5, this.gameObject, false);
            if (((int)transform.position.x) == ((int)pos5.x) && ((int)transform.position.y) == ((int)pos5.y))
            {
                click4 = true;
                goClick4 = false;
                goClick = false;
            }
        }
        if (Input.GetMouseButtonDown(1) && click4 && !click5 && MousePos() != new Vector2(0, 0))
        {
            pos6 = MousePos();
            goClick = true;
            goClick5 = true;
            
            
        }
        if (goClick5)
        {
            Loop(transform.position, pos6, this.gameObject, false);
            if (((int)transform.position.x) == ((int)pos6.x) && ((int)transform.position.y) == ((int)pos6.y))
            {
                click5 = true;
                goClick5 = false;
                goClick = false;
            }
        }
        if (click4 && click5)
        {
            if (cloneobj3 == null)
            {
                cloneobj3 = Instantiate(obj, pos5, Quaternion.identity);
            }
            else
            {
                Loop(pos5, pos6, cloneobj3, true);
            }
        }
    }
    void Follow()
    {
        transform.rotation = player.transform.rotation;
        float mesafe = Vector2.Distance(transform.position, player.transform.position);      
        if(mesafe > distance) 
        {
            transform.position = Vector2.Lerp(transform.position, new Vector2(player.transform.position.x, player.transform.position.y + 1.5f), Time.deltaTime * followSpeed);
        }
    }
}
