using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject followObject;
    public Vector2 followOffset;
    public float speed = 3f;
    private Vector2 threshold;
    private Rigidbody2D rb;
    public bool moveCAM;
    public bool cantReturn;

    // Start is called before the first frame update
    void Start()
    {
        threshold = calculateThreshold();   
        rb = followObject.GetComponent<Rigidbody2D>();
        moveCAM = true;
      //  followObject = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 follow = followObject.transform.position;
        float xDifference = Vector2.Distance(Vector2.right * transform.position.x, Vector2.right * follow.x);
     
        
        Vector3 newPosition = transform.position;
       if(cantReturn == true) { 
            if (moveCAM == true)
            {
                if (Mathf.Abs(xDifference) >= threshold.x)
                {
                    newPosition.x = follow.x;
                }
            }
        }
        else
        {
            if (Mathf.Abs(xDifference) >= threshold.x)
            {
                newPosition.x = follow.x;
            }
        }

        float moveSpeed = rb.velocity.magnitude > speed ? rb.velocity.magnitude : speed;
        transform.position = Vector3.MoveTowards(transform.position, newPosition, moveSpeed * Time.deltaTime);
    }
    private void Update()
    {
        if (cantReturn == true)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                moveCAM = false;
                StopCoroutine("DontReturn");
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                StartCoroutine("DontReturn");
            }
        }
    }
    private Vector3 calculateThreshold()
    {
        Rect aspect = Camera.main.pixelRect;
        Vector2 t = new Vector2(Camera.main.orthographicSize * aspect.width / aspect.height, Camera.main.orthographicSize);
        t.x -= followOffset.x;
        return t;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector2 border = calculateThreshold();
        Gizmos.DrawWireCube(transform.position, new Vector3(border.x * 2, border.y * 2, 1));
    }
    IEnumerator DontReturn()
    {
        yield return new WaitForSeconds(1);
        moveCAM = true;
    }
}
