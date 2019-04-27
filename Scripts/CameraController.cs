using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject followTarget;
    private Vector3 targetPos;
    public float moveSpeed;
    private Vector2 deltaPosition;
    public int shakeDuration;
    private Vector2 shake;
    public bool gameActive = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(followTarget.transform.position.x, transform.position.y, transform.position.z);

        if (followTarget != null)
        {
            targetPos = new Vector3(18.5f+followTarget.transform.position.x + shake.x, transform.position.y + shake.y, transform.position.z);
            //transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
            transform.position = targetPos;

        }
    }
}
