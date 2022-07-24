using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class aa : MonoBehaviour
{
    public Text aText;
   public int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        aText = GameObject.Find("score").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            score += 1;

        }
    }
}
