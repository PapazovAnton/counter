using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;

    private int _mouseButton = 0;
    private int _currentCount = 0;
    private float _delay = 0.5f;
    private bool _isWorking = true;
    private IEnumerator _countcoroutine;

    private void Awake()
    {
        _countcoroutine = Magnifier(_delay);
        StartCoroutine(_countcoroutine);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(_mouseButton))
        {
            _isWorking = !_isWorking;

            if (_isWorking)
            {
                StartCoroutine(_countcoroutine);
            } 
            else
            {
                StopCoroutine(_countcoroutine);
            }
        }
    }

    private IEnumerator Magnifier(float delay)
    {
        var wait = new WaitForSeconds(delay);

        while (_isWorking)
        {
            _currentCount++;
            _text.text = _currentCount.ToString("");
            yield return wait;
        }
    }
}
