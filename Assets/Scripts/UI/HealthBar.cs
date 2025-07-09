using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private int _currentHealth;
    [SerializeField]
    private int _maxHealth;

    [SerializeField]
    private Slider _slider;
    [SerializeField]
    private TextMeshProUGUI _text;
    

    public void Start() {
        SetHealth(_maxHealth);
    }

    public int GetCurrentHealth() { return _currentHealth; }
    public int GetMaxHealth() { return _maxHealth; }
    public int GetCurrentHealthPercentage() { return _currentHealth / _maxHealth; }

    public void SetHealth(int health) {
        health = Mathf.Max(health, 0);
        health = Mathf.Min(health, _maxHealth);
        _currentHealth = health;
        _slider.value = _currentHealth / _maxHealth;
        _text.text = _currentHealth.ToString() + "/" + _maxHealth.ToString();
    }

    public void DealDamage(int damage) {
        SetHealth(_currentHealth - damage);
    }

    public void HealDamage(int healAmount) {
        SetHealth(_currentHealth + healAmount);
    }

    public void SetMaxHealth(int health) {
        health = Mathf.Max(health, 0);
        _maxHealth = health;
        _slider.value = _currentHealth / _maxHealth;
        _text.text = _currentHealth.ToString() + "/" + _maxHealth.ToString();
    }

    public void ChangeMaxHealth(int amount) {
        SetMaxHealth(_maxHealth + amount);
    }
}
