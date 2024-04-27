using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D bullet;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject crossHair;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 10f, Color.green, 10f);

            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if (hit.collider != null)
            {
                crossHair.transform.position = new Vector2(hit.point.x, hit.point.y);
                Debug.Log($"hit point: ({hit.point.x}, {hit.point.y})");

                Vector2 projectile = CalculateProjectileVelocity(shootPoint.position, hit.point, 1f);
                Rigidbody2D firedBullet = Instantiate(bullet, shootPoint.position, Quaternion.identity);
                firedBullet.velocity = projectile;
            }
        }
    }

    Vector2 CalculateProjectileVelocity(Vector2 origin, Vector2 crossHair, float t)
    {
        Vector2 distance = crossHair - origin;

        float distX = distance.x;
        float distY = distance.y;

        float velocityX = distX / t;
        float velocityY = distY / t + 0.5f * Mathf.Abs(Physics2D.gravity.y) * t;

        Vector2 result = new Vector2(velocityX, velocityY);
        return result;
    }
}