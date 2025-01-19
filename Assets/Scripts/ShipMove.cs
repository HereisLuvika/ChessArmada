using UnityEngine;
using UnityEngine.Tilemaps;

public class ShipMove : MonoBehaviour
{
    public Tilemap tilemap;
    public float moveSpeed = 5f; // 이동 속도는 함선마다 조정 필요함, 테스트 빌드 속도는 5f
    public Transform ship;
    private Vector3 targetPosition;

    // 함선 할당 함수, ShipBehavior에서 선택한 함선이 selectedShip이 되어 이동 함선, 현재 위치를 할당
    public void AssignShip(Transform selectedShip)
    {
        ship = selectedShip;
        targetPosition = ship.position;
    }
    public void InitialMove() // 이동 함수
    {
        // 마우스 입력 처리하여 화면 좌표를 월드 좌표로 변환
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWolrdPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWolrdPos.z = 0; // 2D 상이기에 Z는 타일 바로 위로 고정

            // 입력된 마우스 월드 좌표를 타일 셀 좌료로 변환 후 셀 중심을 지정
            Vector3Int cellPos = tilemap.WorldToCell(mouseWolrdPos);
            targetPosition = tilemap.GetCellCenterWorld(cellPos);
        }
    }
    // Update is called once per frame
    void Update()
    {
        // 함선이 없으면 작동 안 함
        if (ship == null)
        {
            return;
        }
        // 타겟 위치 변경이 확인될 경우 이동
        if(ship.position != targetPosition)
        {
            Vector3 moveDir = (targetPosition - ship.position).normalized; // 방향 벡터
            float moveAngle = Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg; // Mathf.Atan2는 y와 x로 각도를 계산하여 라디안 각도 반환, Mathf.Rad2Deg로 라디안을 Degree로 변환
            ship.rotation = Quaternion.Euler(0, 0, moveAngle); //Quaternion.Euler(0, 0, moveAngle)는 각도 기반으로 회전 생성
            ship.position = Vector3.MoveTowards(ship.position, targetPosition, moveSpeed * Time.deltaTime); // MoveTowards로 선형 이동
        }
    }

}
