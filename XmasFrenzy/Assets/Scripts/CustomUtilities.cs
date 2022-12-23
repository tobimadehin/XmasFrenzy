using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomUtilities : MonoBehaviour
{
    //Public
    public Camera mainCamera;
    public List<Enemy> enemies;

    //Private
    private Plane plane = new Plane(Vector3.down, 0);

    private void Awake()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        MouseWorldPosition();
    }

    public Vector3 MouseWorldPosition()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        Vector3 mouseWorldPosition = new Vector3();

        Ray ray = Camera.main.ScreenPointToRay(mouseScreenPosition);

        if (plane.Raycast(ray, out float distance))
        {
            mouseWorldPosition = ray.GetPoint(distance);
        }

        return mouseWorldPosition;
    }

    public int EnemyCount()
    {
        return enemies.Count;
    }
}
