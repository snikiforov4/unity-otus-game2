using UnityEngine;

public class TriggerDetector : MonoBehaviour
{
    
    private TriggerState _state = TriggerState.InAir;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            _state = TriggerState.Drawn;
        }
        else
        {
            _state = TriggerState.OnGround;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (_state == TriggerState.Drawn) return;
        _state = TriggerState.InAir;
    }
    
    public bool Drawn()
    {
        return _state == TriggerState.Drawn;
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