using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{

    [SerializeField] private float _health = 100;
    [SerializeField] private Image HealthBar;
    [SerializeField] private GameObject player;

    public float Health
    {
        get { return _health; }
        set { _health = value; }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void UpdatePlayerHpUI()
    {
        HealthBar.fillAmount = _health/100;
    }

    public void AddHealth(float value)
    {
        Health += value;
        UpdatePlayerHpUI();
    }

    public void RemoveHealth(float value)
    {
        if (_health > 0)
        {
            Health -= value;
            UpdatePlayerHpUI();
        }
        else
        {
            Die();
        }
        
    }

    void Die()
    {
        SceneManager.LoadScene("GameOver");
    }
    
}
