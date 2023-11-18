using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{
    public GameObject obj, player;
    private bool click0 = false, click1 = false, click2 = false, click3 = false, click4 = false, click5 = false;
    private Vector2 pos1, pos2, pos3, pos4, pos5, pos6;
    GameObject cloneobj1, cloneobj2, cloneobj3;
    public float distance, followSpeed;
    private void Start()
    {
   
    }
    private void Update()
    {
        MainMechanic();
        Follow();
    }
    void Loop(Vector2 pos1, Vector2 pos2, GameObject obj)
    {
        obj.transform.position = Vector2.Lerp(obj.transform.position, pos2, Time.deltaTime * 1.5f);
        if (((int)obj.transform.position.x) == ((int)pos2.x) && ((int)obj.transform.position.y) == ((int)pos2.y))
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
            click0 = true;
        }
        if (Input.GetMouseButtonDown(1) && click0 && !click1 && MousePos() != new Vector2(0, 0))
        {
            pos2 = MousePos();
            click1 = true;
            cloneobj1 = Instantiate(obj, pos1, Quaternion.identity);
        }
        if (click0 && click1)
        {
            if (cloneobj1 == null)
            {
                cloneobj1 = Instantiate(obj, pos1, Quaternion.identity);
            }
            else
            {
                Loop(pos1, pos2, cloneobj1);
            }
        }
        if (Input.GetMouseButtonDown(0) && click1 && !click2 && MousePos() != new Vector2(0, 0))
        {
            pos3 = MousePos();
            click2 = true;
        }
        if (Input.GetMouseButtonDown(1) && click2 && !click3 && MousePos() != new Vector2(0, 0))
        {
            pos4 = MousePos();
            click3 = true;
            cloneobj2 = Instantiate(obj, pos3, Quaternion.identity);
        }
        if (click2 && click3)
        {
            if (cloneobj2 == null)
            {
                cloneobj2 = Instantiate(obj, pos3, Quaternion.identity);
            }
            else
            {
                Loop(pos3, pos4, cloneobj2);
            }
        }
        if (Input.GetMouseButtonDown(0) && click3 && !click4 && MousePos() != new Vector2(0, 0))
        {
            pos5 = MousePos();
            click4 = true;
        }
        if (Input.GetMouseButtonDown(1) && click4 && !click5 && MousePos() != new Vector2(0, 0))
        {
            pos6 = MousePos();
            click5 = true;
            cloneobj3 = Instantiate(obj, pos5, Quaternion.identity);
        }
        if (click4 && click5)
        {
            if (cloneobj3 == null)
            {
                cloneobj3 = Instantiate(obj, pos5, Quaternion.identity);
            }
            else
            {
                Loop(pos5, pos6, cloneobj3);
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
