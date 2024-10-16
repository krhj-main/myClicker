using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingProjectile : MonoBehaviour
{
    // 기본 발사체가 날아가는 목표 지점에 대한 변수
    Transform targetT;
    // 발사체의 목표 지점에 대한 Transform 객체
    [Header ("ProjectileSpeed")]
    [SerializeField]
    float speed;
    // 발사체의 날아가는 속도

    Rigidbody2D rig;
    // 발사체의 날아가는 물리적 Rigidbody2D 객체
    
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        // 발사체 객체의 Rigidbody2D 컴포넌트를 가져옴
        targetT = GameObject.Find("targetPoint").transform;        
        // targetPoint의 Transform 컴포넌트를 찾아서 해당 객체에 저장

        startFlying();
        // 날기 시작
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void startFlying()
    {
        Vector2 dir = targetT.position - transform.position;
        // 방향 벡터 => 목표 지점의 위치 - 발사체의 위치

        rig.velocity = dir.normalized * speed * GM.instance.playerAttackSpeed;
        // 방향 벡터의 정규화 * 발사체 속도 * 플레이어 공격 속도
        // 플레이어 공격 속도에 따라 발사체의 속도를 조정

        Destroy(this.gameObject,2f);
        // 발사체가 생성된 후 2초가 지나면 파괴
    }
}
