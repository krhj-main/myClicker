using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 몬스터 상태를 저장하는 클래스
[System.Serializable]
public class MobStatus
{
    public int Speed;
    // 몬스터 이동 속도
    public float Health;
    // 몬스터의 체력
    public float Mass;
    // 몬스터의 질량 -> 물리적 상호작용에 영향을 미침
    public float Sheild;
    // 몬스터의 방어막 -> 몬스터가 받는 피해를 줄여줌
    public float whatMob;
    // 몬스터의 종류를 나타내는 변수
}
// 몬스터 매니저 클래스
// 몬스터의 생성 및 관리에 관련된 기능을 수행합니다.
// 몬스터의 상태를 업데이트하고, 생성 여부를 결정합니다.
// 몬스터의 능력치에 따라 몬스터를 생성합니다.


public class MobManager : MonoBehaviour
{
    static MobManager instance = null;

    public static MobManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
    public MobStatus mob;

    [SerializeField]
    GameObject[] mob_Type = new GameObject[8];
    // 몬스터 종류를 저장하는 배열, 최대 8종의 몬스터를 생성할 수 있습니다.

    bool[] spawnToggle = { true, true, true, true, true, true, true, true, };
    // 몬스터의 생성 여부를 나타내는 배열
    // 각 인덱스에 해당하는 몬스터가 생성되었는지 여부를 true로 초기화합니다.
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WaveStart(GM.instance.AbilityPower);
        // 플레이어의 능력치에 따라 몬스터의 생성 여부를 결정합니다.
        // 몬스터의 상태를 업데이트합니다.
        
    }

    public void WaveStart(float Power)
    {
        // Power에 따라 몬스터의 상태를 업데이트합니다.
        // switch 문을 사용하여 몬스터의 능력치를 설정합니다.
        // 플레이어의 능력치에 따라 몬스터의 생성 여부를 결정합니다.
        // 생성된 몬스터는 false로 설정하여 중복 생성을 방지합니다.


        // 몬스터 1 생성
        if (Power > 10)
        {
            mob.Speed = 60;
            mob.Health = 350;
            mob.Mass = 2;
            mob.Sheild = 0;
            mob.whatMob = 0;
            if (spawnToggle[0])
            {
                Instantiate(mob_Type[0], transform.position, Quaternion.identity);
            }
            spawnToggle[0] = false;
        }

        // 몬스터 2 생성
        if (Power > 20)
        {
            mob.Speed = 100;
            mob.Health = 250;
            mob.Mass = 2;
            mob.Sheild = 0;
            mob.whatMob = 1;
            if (spawnToggle[1])
            {
                Instantiate(mob_Type[1], transform.position, Quaternion.identity);
            }
            spawnToggle[1] = false;
        }

        // 몬스터 3 생성
        if (Power > 30)
        {
            mob.Speed = 150;
            mob.Health = 400;
            mob.Mass = 2;
            mob.Sheild = 0;
            mob.whatMob = 2;
            if (spawnToggle[2])
            {
                Instantiate(mob_Type[2], transform.position, Quaternion.identity);
            }
            spawnToggle[2] = false;
        }

        // 몬스터 4 생성
        if (Power > 40)
        {
            mob.Speed = 80;
            mob.Health = 1200;
            mob.Mass = 2;
            mob.Sheild = 0;
            mob.whatMob = 3;
            if (spawnToggle[3])
            {
                Instantiate(mob_Type[3], transform.position, Quaternion.identity);
            }
            spawnToggle[3] = false;
        }

        // 몬스터 5 생성
        if (Power > 50)
        {
            mob.Speed = 130;
            mob.Health = 1500;
            mob.Mass = 2;
            mob.Sheild = 0;
            mob.whatMob = 4;
            if (spawnToggle[4])
            {
                Instantiate(mob_Type[4], transform.position, Quaternion.identity);
            }
            spawnToggle[4] = false;
        }

        // 몬스터 6 생성
        if (Power > 60)
        {
            mob.Speed = 120;
            mob.Health = 1700;
            mob.Mass = 2;
            mob.Sheild = 0;
            mob.whatMob = 5;
            if (spawnToggle[5])
            {
                Instantiate(mob_Type[5], transform.position, Quaternion.identity);
            }
            spawnToggle[5] = false;
        }

        // 몬스터 7 생성
        if (Power > 70)
        {
            mob.Speed = 80;
            mob.Health = 2000;
            mob.Mass = 2;
            mob.Sheild = 0;
            mob.whatMob = 6;
            if (spawnToggle[6])
            {
                Instantiate(mob_Type[6], transform.position, Quaternion.identity);
            }
            spawnToggle[6] = false;
        }

        // 몬스터 8 생성
        if (Power > 80)
        {
            mob.Speed = 100;
            mob.Health = 5000;
            mob.Mass = 2;
            mob.Sheild = 0;
            mob.whatMob = 7;
            if (spawnToggle[7])
            {
                Instantiate(mob_Type[7], transform.position, Quaternion.identity);
            }
            spawnToggle[7] = false;
        }
    }
}
