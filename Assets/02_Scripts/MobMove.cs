using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobMove : MonoBehaviour
{
    float mob_HP, mob_MaxHP;
    // 몬스터 현재 체력, 최대 체력
    float mob_Sheild;
    // 몬스터 방어막

    Rigidbody2D rig;
    // 몬스터 이동을 위한 물리적 Rigidbody2D 객체
    Transform targetT;
    // 몬스터가 이동할 목표 지점의 객체
    Animator anim;
    // 몬스터 애니메이터 객체
    Image hpBar;
    // 몬스터 체력 바 UI 객체

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        // 몬스터 객체의 Rigidbody2D 컴포넌트를 가져옴
        targetT = GameObject.Find("targetPoint").transform;
        // targetPoint의 Transform 컴포넌트를 가져옴
        hpBar = transform.Find("Canvas").transform.Find("HP_Bar").GetComponent<Image>();
        // 몬스터 체력 바를 표시하기 위한 Canvas -> HP_Bar -> Image 컴포넌트를 가져옴
        anim = GetComponent<Animator>();
        // 몬스터 애니메이터 컴포넌트를 가져옴
        anim.SetFloat("WhatMob", MobManager.Instance.mob.whatMob);
        // 몬스터 애니메이터의 WhatMob 파라미터를 몬스터 종류에 맞게 설정
        MoveStart();
        // 몬스터 이동 시작
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void MoveStart()
    {
        Vector2 Dir = (targetT.position - transform.position).normalized;
        // 방향 = (목표 지점의 위치 - 몬스터의 위치) 정규화

        mob_MaxHP = mob_HP = MobManager.Instance.mob.Health;
        mob_Sheild = MobManager.Instance.mob.Sheild;
        // 몬스터의 최대 체력과 방어막을 설정

        rig.velocity = new Vector2(Dir.x * MobManager.Instance.mob.Speed, 0);
        // 목표 지점의 x좌표에 따라 몬스터가 이동하도록 속도 설정
        rig.mass = MobManager.Instance.mob.Mass;
        // 몬스터의 질량을 설정
    }

    public void HitedFromPlayer()
    {
        if (mob_Sheild > 0)
        {
            mob_Sheild -= GM.instance.playerAttackPower;
            // 방어막이 남아있으면 플레이어 공격력만큼 방어막 감소
        }
        else
        {
            // 방어막이 없으면 몬스터 체력 감소
            mob_HP -= GM.instance.playerAttackPower;
            hpBar.fillAmount = mob_HP / mob_MaxHP;
            // 체력 바의 비율을 현재 체력 / 최대 체력으로 설정
        }

        // 몬스터 체력이 0 이하가 되면
        if (mob_HP <= 0)
        {

            // 몬스터 종류에 따라 보상 지급
            switch (MobManager.Instance.mob.whatMob)
            {
                case 0:
                    GM.instance.playerHaveGold += 20000;
                    GM.instance.defaultIncome += 500;
                    break;
                case 1:
                    GM.instance.playerHaveGold += 25000;
                    GM.instance.defaultIncome += 800;
                    break;
                case 2:
                    GM.instance.playerHaveGold += 30000;
                    GM.instance.defaultIncome += 1500;
                    break;
                case 3:
                    GM.instance.playerHaveGold += 40000;
                    GM.instance.defaultIncome += 2500;
                    break;
                case 4:
                    GM.instance.playerHaveGold += 50000;
                    GM.instance.defaultIncome += 4000;
                    break;
                case 5:
                    GM.instance.playerHaveGold += 70000;
                    GM.instance.defaultIncome += 7000;
                    break;
                case 6:
                    GM.instance.playerHaveGold += 90000;
                    GM.instance.defaultIncome += 10000;
                    break;
                case 7:
                    GM.instance.playerHaveGold += 100000;
                    GM.instance.defaultIncome += 25000;
                    break;
            }

            Destroy(this.gameObject);
            // 몬스터 객체 파괴
        }
    }
}
