using Unity.IntegerTime;
using UnityEngine;

public class ShipBehavior : MonoBehaviour
{
    // ShipBehavior 기능
    public ShipMove shipMoveModule;
    // 선택된 함선
    private Transform selectedShip;

    // Update is called once per frame
    void Update()
    {
        // 현재는 move 동작만 존재하여 update에 할당, 이후 ShipBehavior 열거형을 통한 동작 체크를 추가할 것
        // 각 동작은 함수로 구분 후 열거형 체크로 동작 커맨드를 인식하기
        // 마우스 좌클릭 and 선택된 함선이 있을 경우 이동
        // 마우스 좌클릭 시 함선 선택 기능
        if(Input.GetMouseButtonDown(0) && selectedShip == null)
        {
            SelectShip();
        }
        else if(Input.GetMouseButtonDown(0) && selectedShip != null)
        {
            shipMoveModule.AssignShip(selectedShip);
            shipMoveModule.InitialMove();
            Debug.Log("이동 완료");
            selectedShip = null;
        }
    }
    // 함선 선택
    private void SelectShip()
    {
        // ray를 발사하고 충돌한 대상을 지정
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

        // 충돌 대상 tag가 OurShip이면 선택 가능한 대상이니 선택
        if(hit.collider != null && hit.collider.CompareTag("OurShip"))
        {
            selectedShip = hit.collider.transform;
            Debug.Log($"선택된 함선 : {selectedShip}");
        }
        // 그 외는 유효하지 않은 선택으로 예외처리
        else if(hit.collider == null)
        {
            selectedShip = null;
            Debug.Log("유효하지 않은 선택");
        }
        else // 이후 hit.collider.CompareTag("HostileShip") 조건 넣을 것
        {
            selectedShip = null;
            Debug.Log("조작 대상이 아님");
        }
    }
}
