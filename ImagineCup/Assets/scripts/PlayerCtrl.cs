using UnityEngine;
using System.Collections;

public class PlayerCtrl : MonoBehaviour {


    public enum PlayerState // 플레이어 상태
    {

        Wake_Up, // 처음 씬 스타트 
            // 눈을 뜨고 일어 난 후
        Small_Fire_Find, // 방 안에 작은 불을 발견
            // 소화기를 찾고 잡게 되면 
        Learn_Instructions, // 소화기 사용법을 배움
            // 교육이 끝나고 화재 진압 후
        Large_Fire_Find, // 문 틈새 연기를 보고
            // 문을 열어 큰 불 확인 후
        Call_119, // 전화기를 찾아
            // 신고 후
        Wet_HandkerChief, // 손수건을 찾아서
            // 물에적셔 입에 갖다댄 후
        Escape_House, // 방탈출
            //성공 
        Idle //기타
    };
  
    public PlayerState ps; //플레이어 현재 상태를 저장하기 위한 변수
    [HideInInspector]
    public PlayerState playerState; //플레이어 현재 상태에 따른 액션을 취하기 위한 변수
    public PlayerState PState { get { return playerState; } set { playerState = value; } }  //접근권한을 위한 get set 함수
 

    void Start()
    {
 
        playerState = PlayerState.Wake_Up;
        ps = PlayerState.Wake_Up;
        // 첫 상태는 눈떴을 때!
        StartCoroutine("PlayerAction"); //상태에 따른 행동

    }
   


    void Update()
    {
       
        if (Input.GetKey(KeyCode.Escape))
        {

            Application.LoadLevel("OpeningScene");

        }
    
    }

    public IEnumerator PlayerAction()  //상태에 따른 행동
    {
        yield return new WaitForSeconds(5f); //처음 오큘러스 경고문이 나오므로 5초간 대기 후
        while (true)
        {
            switch (playerState)
            {
                case PlayerState.Wake_Up:  // 처음 씬 스타트                   
                    GameObject.Find("Player").AddComponent<WakeUp>(); //WakeUp 스크립트 부착               
                    break;

                case PlayerState.Small_Fire_Find: // 방 안에 작은 불을 발견
                    GameObject.Find("Player").AddComponent<SmallFireFind>(); //SmallFireFind 스크립트 부착
                    break;

                case PlayerState.Learn_Instructions:// 소화기 사용법을 배움
                    GameObject.Find("Player").AddComponent<LearnInstructions>(); //LearnInstructions 스크립트 부착
                    break;

                case PlayerState.Large_Fire_Find:// 문 틈새 연기를 보고        
                    GameObject.Find("Player").AddComponent<LargeFireFind>(); //LargeFireFind 스크립트 부착
                    break;

                case PlayerState.Call_119:// 전화기를 찾아
                    GameObject.Find("Player").AddComponent<Call119>(); //Call119 스크립트 부착
                    break;

                case PlayerState.Wet_HandkerChief:// 손수건을 찾아서
                    GameObject.Find("Player").AddComponent<WetHandkerChief>(); //Wet_HandkerChief 스크립트 부착
                    break;

                case PlayerState.Escape_House: // 방탈출
                    GameObject.Find("Player").AddComponent<EscapeHouse>(); //Wet_HandkerChief 스크립트 부착
                    break;
            }
            yield return null;
        }


    }
    

    
}
