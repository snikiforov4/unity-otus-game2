using UnityEngine;

public class TriggerDetector : MonoBehaviour
{
    
    private TriggerState _state = TriggerState.InAir;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            _state = TriggerState.Dead;
        }
        else
        {
            _state = TriggerState.OnGround;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (_state == TriggerState.Dead) return;
        _state = TriggerState.InAir;
    }
    
    public bool IsDead()
    {
        return _state == TriggerState.Dead;
    }
    
    public bool InAir()
    {
        return _state == TriggerState.InAir;
    }
    
    public bool OnGround()
    {
        return _state == TriggerState.OnGround;
    }
}