using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchToLook : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 5f;
    [SerializeField] private float _MouseZDist = 10f;

    private Vector3 mousePos;
    private Camera mainCamera;
    private Transform localTrans;

    // Start is called before the first frame update
    void Start()
    {
        localTrans = GetComponent<Transform>();
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    public void Look() {
        // get the world position of the mouse
        mousePos = mainCamera.ScreenToWorldPoint( new Vector3(Input.mousePosition.x, Input.mousePosition.y, _MouseZDist) );

        // determine the target rotation
        Quaternion targetRot = Quaternion.LookRotation(mousePos - localTrans.position);

        // smoothly rotate towards the target point.
        localTrans.rotation = Quaternion.Slerp(localTrans.rotation, targetRot, _rotateSpeed * Time.deltaTime);
    }
}
