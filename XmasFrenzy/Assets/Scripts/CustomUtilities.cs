using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Xml.Serialization;

public class CustomUtilities : MonoBehaviour
{
    //Public
    public Camera mainCamera;
    public List<Enemy> enemies;
    public TextMeshProUGUI enemiesCountText;
    public Image healthBar;
    public GameObject gameOverPanel;

    //Private
    private Plane plane = new Plane(Vector3.down, 0);

    private void Awake()
    {
        Cursor.visible = false;
    }

    private void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        MouseWorldPosition();
        EnemiesCountText();
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

    private TextMeshProUGUI EnemiesCountText()
    {
        enemiesCountText.text = enemies.Count.ToString();
        return enemiesCountText;
    }

    public void HealthBarsUpdate(Image i, Player player, int factor)
    {
        i.fillAmount = player.health / factor;
    }

    public bool GameOverChecker(float health)
    {
        bool isDead = false;

        if (health <= 0)
        {
            gameOverPanel.SetActive(true);
            isDead = true;
            Time.timeScale = 0;
        }

        return isDead;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
