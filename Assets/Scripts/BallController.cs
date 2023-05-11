using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BallController : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float force;
    [SerializeField] LineRenderer aimLine;
    [SerializeField] Transform aimWorld;

    int shots = 0;
    float forceFactor;
    bool shoot;
    bool shootingMode;
    public bool ShootingMode {get => shootingMode;}
    public int GetShots { get => shots; }
    Ray ray;
    Plane plane;
    Vector3 forceDirection;

    void Update()
    {
        var clickOncePress = Input.GetMouseButtonDown(0);
        var clickOnceRelease = Input.GetMouseButtonUp(0);
        var clickAndHold = Input.GetMouseButton(0);

        if (shootingMode) 
        {
            if (clickOncePress) 
            {
                aimWorld.gameObject.SetActive(true);
                aimLine.gameObject.SetActive(true);
                plane = new Plane(Vector3.up, this.transform.position);
            } 
            else if (clickAndHold)
            {
                // Init Variable
                var mouseViewportPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
                var ballViewportPos = Camera.main.WorldToViewportPoint(this.transform.position);
                var pointerDirection = ballViewportPos - mouseViewportPos;
                pointerDirection.z = 0; // Tidak Ada Pointer Direction Z

                // Force Direction
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                plane.Raycast(ray, out var distance);
                forceDirection = this.transform.position - ray.GetPoint(distance);
                forceDirection.Normalize();

                // Force Factor (Faktor Pendorong)
                forceFactor = pointerDirection.magnitude * 2;
                
                // Aim visuals
                aimWorld.transform.position = this.transform.position;
                aimWorld.forward = forceDirection;
                aimWorld.localScale = new Vector3(1,1,0.5f + forceFactor);

                // Aim visual tail line
                var ballScreenPos = Camera.main.WorldToScreenPoint(this.transform.position);
                var mouseScreenPos = Input.mousePosition;
                ballScreenPos.z = 1f;
                mouseScreenPos.z = 1f;
                var positions = new Vector3[] { 
                    Camera.main.ScreenToWorldPoint(ballScreenPos), 
                    Camera.main.ScreenToWorldPoint(mouseScreenPos) 
                };
                aimLine.SetPositions(positions);
            } 
            else if(clickOnceRelease) 
            {
                shots += 1;
                shoot = true;
                shootingMode = false;
                aimWorld.gameObject.SetActive(false);
                aimLine.gameObject.SetActive(false);
            }
        }
    }
    
    void FixedUpdate()
    {
        if (shoot)
        {
            shoot = false;
            rb.AddForce(forceDirection * force * forceFactor, ForceMode.Impulse);
        }

        //Memaksa berhenti bola
        if (rb.velocity.sqrMagnitude < 0.01f && rb.velocity.sqrMagnitude > 0)
        {
            rb.velocity = Vector3.zero;
        }
    }

    public bool IsMove()
    {
        return rb.velocity != Vector3.zero;
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        if (this.IsMove())
        {
            return;
        }
        shootingMode = true;
    }
}
