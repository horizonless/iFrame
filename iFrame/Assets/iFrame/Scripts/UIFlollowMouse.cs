using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFlollowMouse : MonoBehaviour
{
    public RectTransform MovingObject;
    public Vector3 offset;
    public RectTransform BasisObject;
    public Camera cam;

    public void MoveObject()
    {
        Vector3 pos = Input.mousePosition + offset;
        pos.z = BasisObject.position.z;
        MovingObject.position = cam.ScreenToWorldPoint(pos);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveObject();
    }
}
