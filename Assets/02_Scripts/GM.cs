using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    public static GM instance = null;
    // 시작은 첫 번째 프레임 업데이트 전에 호출됩니다.
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
                Destroy(this.gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    // 플레이어 공격력
    // 플레이어 공격 속도
    // 플레이어 능력치
    // 플레이어 금액

    [Header ("플레이어 정보")]
    [Tooltip ("플레이어 공격력")]
    public float playerAttackPower;
    [Tooltip("플레이어 공격 속도")]
    public float playerAttackSpeed;
    [HideInInspector]
    public float AbilityPower;
    [Tooltip("플레이어 보유 금액")]
    public int playerHaveGold;

    [Space (15)]
    [Header("상점 정보")]
    // 상점 파워 가격
    // 상점 파워 구매 수량
    // 상점 속도 가격
    // 상점 속도 구매 수량
    [Tooltip("상점 파워 가격")]
    public int shopPowerPrice;
    [HideInInspector]
    public int shopPowerBuy;
    [Tooltip("상점 속도 가격")]
    public int shopSpeedPrice;
    [HideInInspector]
    public int shopSpeedBuy;


    // 상점 파워 증가 수량
    // 상점 속도 증가 수량
    [HideInInspector]
    public int shopIncreasePower;
    [HideInInspector]
    public int shopIncreaseSpeed;

    [Space(15)]
    // 기본 수입 설정
    [Header ("기본 수입 설정")]
    [Tooltip ("기본 수입을 설정합니다.")]
    public int defaultIncome;

    private void Start()
    {
        
    }
    private void Update()
    {
        AbilityPower = (playerAttackPower/8) * playerAttackSpeed;
        // 플레이어 능력치 = 플레이어 공격력 / 8 * 플레이어 공격 속도
    }

}
