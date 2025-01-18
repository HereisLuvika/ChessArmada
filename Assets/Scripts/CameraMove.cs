using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private float moveSpeed = 8.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 대각선 이동
        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-moveSpeed * Time.deltaTime, moveSpeed * Time.deltaTime, 0);
        }
        else if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(-moveSpeed * Time.deltaTime, -moveSpeed * Time.deltaTime, 0);
        }
        else if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(moveSpeed * Time.deltaTime, -moveSpeed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(moveSpeed * Time.deltaTime, moveSpeed * Time.deltaTime, 0);
        }
        // 4방향 이동
        else if(Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        } 
        else if(Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0, 0);
        }
        else if(Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, -moveSpeed * Time.deltaTime, 0);
        }
    }
}
