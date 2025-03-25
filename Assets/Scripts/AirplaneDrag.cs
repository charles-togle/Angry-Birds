using UnityEngine;
using UnityEngine.UIElements;

public class AirplaneDrag : MonoBehaviour
{
    private Rigidbody2D AirplaneRB => GetComponent<Rigidbody2D>();
    private bool isDragging = false;
    private bool isFlying = false;
    private bool isDraggable = true;
    private Vector3 DragPosition;
    [SerializeField] private float Power = 2f;
    [SerializeField] GameObject TrajectoryObject;
    private Trajectory Trajectory => TrajectoryObject.GetComponent<Trajectory>();
    float time = 0;

    void Start()
    {
        AirplaneRB.bodyType = RigidbodyType2D.Static;
    }

    void Update()
    {
        if (isDraggable && isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
            Vector2 velocity = (DragPosition - transform.position) * Power;
            Trajectory.ShowTrajectory(transform.position, velocity, AirplaneRB.gravityScale);

            float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
            return;
        }

        if (isFlying)
        {
            Vector2 currentVelocity = AirplaneRB.linearVelocity;
            float angle = Mathf.Atan2(currentVelocity.y, currentVelocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
            return;
        }

        time += Time.deltaTime;
        if (time >= 5)
        {
            isDragging = false;
            isFlying = false;
            isDraggable = true;
            AirplaneRB.bodyType = RigidbodyType2D.Static;
            time = 0;
            transform.position = new Vector3((float)-5.38, (float)0.18, 0);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void OnMouseDown()
    {
        if (isDraggable)
        {
            isDragging = true;
            DragPosition = transform.position;
        }
    }

    void OnMouseUp()
    {
        if (isDraggable)
        {
            isDragging = false;
            isFlying = true;
            isDraggable = false;
            AirplaneRB.bodyType = RigidbodyType2D.Dynamic;
            Vector3 releaseForce = (DragPosition - transform.position) * Power;
            AirplaneRB.linearVelocity = releaseForce;
            Trajectory.HideTrajectory();

            float angle = Mathf.Atan2(releaseForce.y, releaseForce.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        isFlying = false;
        isDraggable = false;
    }
}