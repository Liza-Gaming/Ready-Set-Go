using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Got help from chat GPT and this video: https://www.youtube.com/watch?v=smlgtS07jaQ&ab_channel=MartinDev
public class DoorInteraction : MonoBehaviour
{
    public float openAngle = 90f;
    public float openSpeed = 2f;
    public bool isOpen = false;
    public float activationRadius = 5f; // The radius within which the player can activate the door

    private Quaternion _closedRotation;
    private Quaternion _openRotation;
    private Coroutine _currentCoroutine;
    private Transform _playerTransform; // To keep track of the player's position

    void Start()
    {
        _closedRotation = transform.rotation;
        _openRotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, openAngle, 0));

        GameObject player = GameObject.FindGameObjectWithTag("Player"); // Find the player GameObject by tag
        if (player != null)
        {
            _playerTransform = player.transform;
        }
    }

    void Update()
    {
        if (_playerTransform != null && Vector3.Distance(_playerTransform.position, transform.position) <= activationRadius)
        {
            if (Input.GetMouseButtonDown(1) || Input.GetKey(KeyCode.Space)) // Right mouse button clicked
            {
                if (_currentCoroutine != null) StopCoroutine(_currentCoroutine);
                _currentCoroutine = StartCoroutine(ToggleDoor());
            }
        }
    }

    private IEnumerator ToggleDoor()
    {
        Quaternion targetRotation = isOpen ? _closedRotation : _openRotation;
        isOpen = !isOpen;

        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.01f)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * openSpeed);
            yield return null;
        }

        transform.rotation = targetRotation;
    }
}
