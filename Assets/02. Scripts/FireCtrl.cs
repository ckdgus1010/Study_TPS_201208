using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour
{
    // 총알 프리팹
    public GameObject bullet;
    // 총알 발사 좌표
    public Transform firePos;
    // 총구 화염 파티클
    private ParticleSystem muzzleFlash;

    private void Start()
    {
        // FirePos 하위에 있는 컴포넌트 추출
        muzzleFlash = firePos.GetComponentInChildren<ParticleSystem>();
    }

    void Update()
    {
        // 마우스 왼쪽 버튼을 클릭했을 때 Fire 함수 호출
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    void Fire()
    {
        // Bullet 프리팹을 동적으로 생성
        Instantiate(bullet, firePos.position, firePos.rotation);
        // 총구 화염 파티클 실행
        muzzleFlash.Play();
    }
}
