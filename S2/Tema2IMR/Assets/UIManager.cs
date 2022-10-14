using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    public int Score { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        _scoreText.text = "Score: " + 0;
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
            _scoreText.text = "Score: " + this.Score.ToString();
            Debug.Log($"Scor total: {Score}");

        }
        if (collision.gameObject.name == "2 point Cube")
        {
            Debug.Log("Am luat 2 puncte");
            Score += 2;
            _scoreText.text = "Score: " + this.Score.ToString();
            Debug.Log($"Scor total: {Score}");
        }
        if (collision.gameObject.name == "5 point Cube")
        {
            Debug.Log("Am luat 5 puncte");
            Score += 5;
            _scoreText.text = "Score: " + this.Score.ToString();
            Debug.Log($"Scor total: {Score}");
        }
    }
}
