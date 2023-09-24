using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDelete : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Transform LookObject;
    [SerializeField] Vector3 _direction;
    // Update is called once per frame
    void Update()
    {
         Test();
    }
    private void Test()
    {
        LookObject.LookAt(target, _direction);
        LookObject.transform.Rotate(new Vector3(90, 0, 0));
    }
    
}
