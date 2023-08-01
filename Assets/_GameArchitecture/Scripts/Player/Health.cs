using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private GameObject _playerInput;
    public Action<float> OnHealthUpdated;
    public Action OnDeath;
    private float _health;
    public static Health _instance;
    public bool IsDead { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        _health = _maxHealth;
        OnHealthUpdated?.Invoke(_health);
    }

    public void DeductHealth(float value)
    {
        if (IsDead) return; //guard clause

        _health -= value;
        if (_health <= 0)
        {
            IsDead = true;
            OnDeath?.Invoke();
            _playerInput.gameObject.SetActive(false);
            _health = 0;
        }
        OnHealthUpdated?.Invoke(_health);
    }
}
