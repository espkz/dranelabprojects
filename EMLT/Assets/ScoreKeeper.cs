using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public Dictionary<string, int> scores = new Dictionary<string, int>();
    private bool hasCollided = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Current Scores:");
            foreach (KeyValuePair<string, int> kvp in scores)
            {
                Debug.Log(string.Format("Key = {0}, Value = {1}", kvp.Key, kvp.Value));
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasCollided) {
            hasCollided = true;
            string collided = other.gameObject.name;
            StartCoroutine(countScores(collided));
        }
    }

    IEnumerator countScores(string collided) 
    {
        if (scores.ContainsKey(collided))
        {
            int value = scores[collided];
            value++;
            scores.Remove(collided);
            scores[collided] = value;
        }

        else {
            scores[collided] = 1;
        }
        yield return new WaitForSeconds(1f);
        hasCollided = false;
    }
}
