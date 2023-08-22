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
        
        TouchMove(rb,10);
    }
    void TouchMove(Rigidbody2D rb, float moveSpeed){
        if (Input.touchCount > 0){
            Debug.Log(1);
            Touch touch = Input.GetTouch(0);
            Debug.Log(2);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            MoveFish(touchPosition,moveSpeed);
            
        }
        else if (Input.GetMouseButton(0)) {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            //rb.MovePosition(mousePosition);
            MoveFish(mousePosition,moveSpeed);
        }
        else rb.velocity = Vector2.Lerp(
            rb.velocity,
            Vector2.zero,
            Time.deltaTime
        );
    }
    void MoveFish(Vector3 touchPosition, float moveSpeed){
        Vector3 direction = (touchPosition - transform.position).normalized;
        rb.velocity = Vector2.Lerp(
            rb.velocity,
            Vector2.right * direction.x * moveSpeed + Vector2.up * direction.y * moveSpeed,
            Time.deltaTime
        );
        /*
        Quaternion rotation = Quaternion.LookRotation(transform.position + direction);
        rotation.x = 0;rotation.y = 0;

        // Rotate the object.
        transform.rotation = rotation;
        */
        rb.MoveRotation(rb.rotation + moveSpeed * -direction.x * 100 * Time.deltaTime);
    }
}
