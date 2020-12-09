using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private float h = 0.0f;
    private float v = 0.0f;

    private Transform tr;
    public float moveSpeed = 10.0f;

    void Start()
    {
        tr = GetComponent<Transform>();
    }

    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Debug.Log("h=" + h.ToString());
        Debug.Log("v=" + v.ToString());

        //Translate(이동 방향 * 속도 * 변위값 * Time.deltaTime, 기준 좌표)
        tr.Translate(Vector3.forward * moveSpeed * v * Time.deltaTime, Space.Self);
    }
}
