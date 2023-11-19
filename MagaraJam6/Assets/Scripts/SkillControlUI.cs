using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class SkillControlUI : MonoBehaviour
{
    private int totalLoop, x;
    public Sprite sp;
    public bool skill;

    private void Start()
    {
        totalLoop = GameObject.FindGameObjectWithTag("Machine").GetComponent<Machine>().totalLoop;
        x = totalLoop;
        print(totalLoop);
        for (int i = 0; i < totalLoop; i++)
        {
            Transform childTransform = transform.GetChild(i);
            childTransform.gameObject.SetActive(true);
        }
    }
    private void Update()
    {
        while (skill)
        {
            Transform childTransform = transform.GetChild(x - 1);
            childTransform.GetComponent<UnityEngine.UI.Image>().sprite = sp;
            x--;
            skill = false;
        }
    }
}


