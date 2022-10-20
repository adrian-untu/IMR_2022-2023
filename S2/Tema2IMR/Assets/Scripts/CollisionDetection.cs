using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using TMPro;

public class CollisionDetection : MonoBehaviour
{
    public GameObject hand;
    private bool grab_tool;
    // Start is called before the first frame update
    void Start()
    {
        grab_tool = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(grab_tool == true)
        {
            hand.GetComponent<Animator>().SetTrigger("TrGrab");
        }
        if(Input.GetKeyDown(KeyCode.G))
        {
            grab_tool = true;
        }
        if(Input.GetKeyUp(KeyCode.G))
        {
            grab_tool= false;
            hand.GetComponent<Animator>().SetTrigger("TrIdle");
            hand.GetComponent<Animator>().ResetTrigger("TrGrab");
        }
    }
    
}
