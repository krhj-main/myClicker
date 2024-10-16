using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    // UI 매니저 클래스입니다.


    static UIManager instance = null;
    public static UIManager Instance
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
    }

    TextMeshProUGUI goldT, powerT;
    // 금화 UI 텍스트
    // 현재 금화 , 공격력 텍스트
    TextMeshProUGUI shop_Power, shop_Power5M, shop_Speed, shop_Speed5M;
    // 상점 UI 텍스트 
    // 공격력, 공격속도 5배 텍스트

    // Start is called before the first frame update
    void Start()
    {
        goldT = GameObject.Find("Gold_txt").GetComponent<TextMeshProUGUI>();
        powerT = GameObject.Find("Power_txt").GetComponent<TextMeshProUGUI>();
        // 금화 UI 텍스트를 가져오고, 공격력 텍스트를 가져옵니다.

        shop_Power = GameObject.Find("PowerUp_TXT").GetComponent<TextMeshProUGUI>();
        shop_Power5M = GameObject.Find("PowerUp_5MTXT").GetComponent<TextMeshProUGUI>();
        shop_Speed = GameObject.Find("SpeedUp_TXT").GetComponent<TextMeshProUGUI>();
        shop_Speed5M= GameObject.Find("SpeedUp_5MTXT").GetComponent<TextMeshProUGUI>();
        // 상점 관련 텍스트를 가져옵니다.

        
        TextUpdate();
        // UI 텍스트를 업데이트합니다.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void TextUpdate()
    {
        // UI 텍스트 업데이트
        updateGold();
        updatePower();



        // 상점 UI 텍스트 업데이트
        // 공격력
        // 공격력 :
        // 공격력 가격 : 현재 가격
        shop_Power.text = string.Format("Power Upgrade\n" +
                                        "Cost : {0}\n" +
                                        "Lv : {1}"
                                        ,GM.instance.shopPowerPrice,GM.instance.shopPowerBuy);
        shop_Power5M.text = string.Format("Power Upgrade\n" +
                                        "Cost : {0}\n" +
                                        "Lv : {1}"
                                        , GM.instance.shopPowerPrice * 5, GM.instance.shopPowerBuy/5);
        shop_Speed.text = string.Format("Power Upgrade\n" +
                                        "Cost : {0}\n" +
                                        "Lv : {1}"
                                        , GM.instance.shopSpeedPrice, GM.instance.shopSpeedBuy);
        shop_Speed5M.text = string.Format("Power Upgrade\n" +
                                        "Cost : {0}\n" +
                                        "Lv : {1}"
                                        , GM.instance.shopSpeedPrice * 5, GM.instance.shopSpeedBuy/5);
    }
    public void updateGold()
    {
        goldT.text = string.Format("Gold : {0}\\", (int)GM.instance.playerHaveGold);
        // Gold : 현재 금화
    }
    public void updatePower()
    {
        powerT.text = string.Format("Power : {0:N2}", GM.instance.AbilityPower);
        // Power : 현재 공격력은 소수점 2자리로 표시
    }
    public void PowerUp()
    {
        // 공격력을 증가시키는 메서드
        if (GM.instance.playerHaveGold >= GM.instance.shopPowerPrice)
        {
            GM.instance.playerAttackPower += 2f;
            // 공격력 2 증가
            GM.instance.playerHaveGold -= GM.instance.shopPowerPrice;
            // 상점 가격만큼 금화 감소
            GM.instance.shopPowerPrice += GM.instance.shopIncreasePower;
            // 상점 가격 증가
            GM.instance.shopPowerBuy++;
            // 상점 구매 횟수 1 증가
            
            TextUpdate();
            // UI 텍스트 업데이트
        }
    }
    public void PowerUp5M()
    {
        for (int i = 0; i < 5; i++)
        {
            PowerUp();
        }
        // 공격력을 5번 증가시킴
    }
    public void SpeedUp()
    {
        // 공격속도를 증가시키는 메서드
        if (GM.instance.playerHaveGold >= GM.instance.shopSpeedPrice)
        {
            GM.instance.playerAttackSpeed += 0.025f;
            // 공격속도 증가
            // 현재 속도에 따라 증가
            GM.instance.playerHaveGold -= GM.instance.shopSpeedPrice;
            GM.instance.shopSpeedPrice += GM.instance.shopIncreaseSpeed;
            GM.instance.shopSpeedBuy++;
            
            TextUpdate();
        }
    }
    public void SpeedUp5M()
    {
        for (int i = 0; i < 5; i++)
        {
            SpeedUp();
        }
        // 공격속도를 5번 증가시킴
    }
}
