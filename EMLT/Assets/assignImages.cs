using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class assignImages : MonoBehaviour
{
    public GameObject[] faces = new GameObject[6];
    public string[] imageNames = new string[6];
    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i < faces.Length; i++) {
            AssignImageToChild(i);
        }
    }
    void AssignImageToChild(int index)
    {
        GameObject face = faces[index];
        string name = imageNames[index];

        GameObject child = face.transform.GetChild(0).gameObject;

        SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();
        Sprite sprite = Resources.Load<Sprite>(name);

        if (sprite != null)
        {
            // Assign the sprite to the SpriteRenderer
            spriteRenderer.sprite = sprite;
        }
        else
        {
            Debug.LogError("Image not found: " + name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
