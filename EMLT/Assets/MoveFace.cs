using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFace : MonoBehaviour
{
    public GameObject face;
    private bool moving = false;
    public Vector3 startpos = new Vector3(-29, -20, 0);

    // walls
    public Collider2D leftWall;
    public Collider2D rightWall;
    public Collider2D topWall;
    public Collider2D bottomWall;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = startpos;
    }

    // Update is called once per frame
    private void Update()
    {
        // Debug.Log(Input.mousePosition.ToString());
        ConstrainPosition();
        if (moving) {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            transform.position = mousePos;
            ConstrainPosition();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Move the sprite instantly to the target position
            transform.position = startpos;
        }
    }

    void OnMouseDown()
    {
        moving = true;
        // Debug.Log("clicked");
    }

    void OnMouseUp()
    {
        moving = false;
        // Debug.Log("not clicked");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "target")
        {
            Debug.Log("Collided with target");
            // doesn't seem to be resetting to original position?
            face.SetActive(false);
            face.transform.position = startpos; 
            face.SetActive(true);
            Debug.Log("Moved back to position");
        }
    }
    void ConstrainPosition()
    {
        // Get the sprite's position
        Vector3 spritePosition = transform.position;

        // Clamp the sprite's position to stay within each boundary
        float clampedX = Mathf.Clamp(spritePosition.x, 
                                     leftWall.bounds.max.x, 
                                     rightWall.bounds.min.x);
        float clampedY = Mathf.Clamp(spritePosition.y, 
                                     bottomWall.bounds.max.y, 
                                     topWall.bounds.min.y);

        // Set the new position
        transform.position = new Vector3(clampedX, clampedY, spritePosition.z);
    }
}
