using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class는 System.Serializable이라는 Attribute를 명시해야 inspector view에 노출됨
[System.Serializable]
public class PlayerAnim
{
    public AnimationClip idle;
    public AnimationClip runF;
    public AnimationClip runB;
    public AnimationClip runL;
    public AnimationClip runR;
}

public class PlayerCtrl : MonoBehaviour
{
    private float h = 0.0f;
    private float v = 0.0f;
    private float r = 0.0f;

    private Transform tr;
    public float moveSpeed = 10.0f;
    public float rotSpeed = 80.0f;

    //Inspector view에 표시할 애니메이션 class 변수
    public PlayerAnim playerAnim;
    //Animation 컴포넌트를 저장하기 위한 변수
    [HideInInspector]public Animation anim;

    void Start()
    {
        tr = GetComponent<Transform>();
        anim = GetComponent<Animation>();
        anim.clip = playerAnim.idle;
        anim.Play();
    }

    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        r = Input.GetAxis("Mouse X");

        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);
        //Translate(이동 방향 * 속도 * 변위값 * Time.deltaTime, 기준좌표)
        tr.Translate(moveDir.normalized * moveSpeed * Time.deltaTime, Space.Self);

        tr.Rotate(Vector3.up * rotSpeed * Time.deltaTime * r);

        //키보드 입력값을 기준으로 동작할 애니메이션 수행
        if (v >= 0.1f)
        {
            anim.CrossFade(playerAnim.runF.name, 0.3f); //전진 애니메이션
            Debug.Log("전진");
        }
        else if (v <= -0.1f)
        {
            anim.CrossFade(playerAnim.runB.name, 0.3f); //후진 애니메이션
            Debug.Log("후진");
        }
        else if (h >= 0.1f)
        {
            anim.CrossFade(playerAnim.runR.name, 0.3f); //오른쪽 애니메이션
            Debug.Log("오른쪽");
        }
        else if (h <= -0.1f)
        {
            anim.CrossFade(playerAnim.runL.name, 0.3f); //왼쪽 애니메이션
            Debug.Log("왼쪽");
        }
        else
        {
            anim.CrossFade(playerAnim.idle.name, 0.3f); //정지 시 Idle 애니메이션
            Debug.Log("정지");
        }
    }
}
