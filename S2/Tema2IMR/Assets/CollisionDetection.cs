using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollisionDetection : MonoBehaviour
{
    public int Score { get; set; }
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "1 point Cube")
        {
            Debug.Log("Am luat 1 punct");
            Score++;
            text.GetComponent<TextMeshPro>().text = "Score: " + Score;
            Debug.Log($"Scor total: {Score}");
        }
        if (collision.gameObject.name == "2 point Cube")
        {
            Debug.Log("Am luat 2 puncte");
            Score += 2;
            text.GetComponent<TextMeshPro>().text = "Score: " + Score;
            Debug.Log($"Scor total: {Score}");
        }
        if (collision.gameObject.name == "5 point Cube")
        {
            Debug.Log("Am luat 5 puncte");
            Score += 5;
            text.GetComponent<TextMeshPro>().text = "Score: " + Score;
            Debug.Log($"Scor total: {Score}");
        }
    }
}
