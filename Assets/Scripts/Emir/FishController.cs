using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FishController : MonoBehaviour
{
    public float i = 0;
    private bool isDragging = false;
    private Vector3 offset;
    Rigidbody2D rb;
    void Start()
    {
        rb =GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
        TouchMove(rb,1);
    }
    void TouchMove(Rigidbody2D rb, float moveSpeed){
        if (Input.touchCount > 0){
            Debug.Log(1);
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved){
                Debug.Log(2);
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                touchPosition.z = 0;
                Vector3 direction = (touchPosition - transform.position).normalized;
                rb.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
            }
            
        }
        else if (Input.GetMouseButton(0)) {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            //rb.MovePosition(mousePosition);
            Vector3 direction = (mousePosition - transform.position).normalized;
            rb.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
        }
        else rb.velocity = Vector2.zero;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
