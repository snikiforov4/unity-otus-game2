using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform[] path;
    public float speed;
    public int startPoint;

    private Transform _from;
    private Transform _to;
    
    private float _currentPosition; // from 0 to 1
    private int _platformDestinationIdx;
    private int _direction;

    void Start()
    {
        _currentPosition = 0.0f;
        _direction = 1;
        _platformDestinationIdx = startPoint;
        _from = path[_platformDestinationIdx];
        CalcNextPlatformDestinationIdx();
        _to = path[_platformDestinationIdx];
    }

    void Update()
    {
        _currentPosition += speed * Time.deltaTime;
        if (_currentPosition > 1.0f)
        {
            _currentPosition = 0.0f;
            _from = _to;
            CalcNextPlatformDestinationIdx();
            _to = path[_platformDestinationIdx];
        }

        transform.position = Vector3.Lerp(_from.position, _to.position, _currentPosition);
    }

    private void CalcNextPlatformDestinationIdx()
    {
        if (_platformDestinationIdx >= path.Length - 1)
        {
            _direction = -1;
        }

        if (_platformDestinationIdx <= 0)
        {
            _direction = 1;
        }

        _platformDestinationIdx += _direction;
    }
}