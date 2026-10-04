using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool jump;
    
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float turnSpeed = 150f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float lHorizontal = Input.GetAxis("Horizontal");
        float lVertical = Input.GetAxis("Vertical");
        
        Vector3 lDirection = new Vector3(-lVertical, 0f, lHorizontal);

        transform.position += lDirection * moveSpeed * Time.deltaTime;
    }
}
