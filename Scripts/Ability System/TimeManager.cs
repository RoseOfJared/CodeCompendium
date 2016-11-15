using System;
using UnityEngine;
using UnityEngine.Events;
 
public class TimeManager : MonoBehaviour
{
    public float DeltaTime { get { return Time.deltaTime * _timeScale; } }
    public float FixedDeltaTime { get { return Time.fixedDeltaTime * _timeScale; } }
 
    #region Pause/Unpause
 
    [Header("Pause/Unpause")]
    [SerializeField, Range(0,1)]
    private float _timeScale;
 
    [SerializeField]
    private PauseEvent _onPause = new PauseEvent();
    public PauseEvent OnPause { get { return _onPause; } }
 
    public void Pause()
    {
        _timeScale = 0;
        if (OnPause != null)
            OnPause.Invoke(true);
    }
 
    [SerializeField]
    private PauseEvent _onUnpause = new PauseEvent();
    public PauseEvent OnUnpause { get { return _onUnpause; } }
 
    public void UnPause()
    {
        _timeScale = 1;
        if (OnUnpause != null)
            OnUnpause.Invoke(false);
    }
 
    [Serializable]
    public class PauseEvent : UnityEvent<bool>
    {
    }
 
    #endregion
 
    #region Ticks
 
    [Header("Ticks")]
    [SerializeField]
    private int _ticks;
    public int Ticks { get { return _ticks; } }
 
    [SerializeField]
    private TickEvent _onTick = new TickEvent ();
    public TickEvent OnTick { get { return _onTick; } }
 
    public void Tick()
    {
        _ticks++;
        if (OnTick != null)
            OnTick.Invoke(_ticks);
    }
 
    [Serializable]
    public class TickEvent : UnityEvent<int>
    {
    }
 
    #endregion
}