
using UnityEngine;

public class FloorLewer : MonoBehaviour
{
    [SerializeField] private Transform startPoint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //який персонаж саме (не NPS (суперник)), створюємо тег і починає спочатку рівня
        if(collision.tag == "Player")
        {
            collision.transform.position = startPoint.position;
            Transform cam = Camera.main.transform;// доступаємось до камери
            cam.position = new Vector3(collision.transform.position.x, cam.position.y, -10);//-10 камера перед обєктами

        }
    }
}
