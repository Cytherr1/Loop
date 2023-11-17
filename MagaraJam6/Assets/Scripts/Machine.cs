using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{
    public Transform pos1, pos2;
    public GameObject obj;
    private bool isSpawn;
    GameObject cloneobj;
    private void Start()
    {
        isSpawn = false;
    }
    private void Update()
    {
        if(!isSpawn)
        {
            isSpawn = true;      
            Loop();
        }
        
        
    }
    void Loop()
    { 
        print("aa");    
        cloneobj = Instantiate(obj, pos1.position, Quaternion.identity);
        cloneobj.transform.position = Vector3.Lerp(cloneobj.transform.position, pos2.position, Time.deltaTime * 1.5f);
        if (((int)cloneobj.transform.position.x) == ((int)pos2.position.x) && ((int)cloneobj.transform.position.y) == ((int)pos2.position.y))
        {
            Destroy(cloneobj);
        }
    }
}
