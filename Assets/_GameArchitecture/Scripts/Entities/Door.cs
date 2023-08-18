using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    //[SerializeField] private MeshRenderer _doorMeshRenderer;
    //[SerializeField] private Material _doorMaterial;
    //[SerializeField] private Material _triggerMaterial;
    [SerializeField] private Animator _doorAnim;
    [SerializeField] AudioSource _doorAudioSource;

    private bool _isLocked = true;

    private float _timer = 0;

    private float _waitTime = 1.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (!_isLocked && other.CompareTag("Player"))
        {
            _timer = 0;
            //_doorMeshRenderer.material = _triggerMaterial;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (_isLocked) return;
        if (!other.CompareTag("Player")) return;

        _timer += Time.deltaTime;

        if (_timer >= _waitTime)
        {
            _timer = _waitTime;
            _doorAnim.SetBool("Open", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _doorAnim.SetBool("Open", false);
    }

    public void LockDoor()
    {
        _isLocked = true;
    }

    public void UnlockDoor()
    {
        _isLocked = false;

    }

    public void OpenDoor(bool state)
    {
        if(!_isLocked)
        {
            _doorAnim.SetBool("Open", state);
            _doorAudioSource.Play();
        }
            
    }
}
