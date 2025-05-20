using System;

namespace ExpressElevator.Event
{
    public class EventController
    {
        public event Action BaseEvent;
        public void InvokeEvent() => BaseEvent?.Invoke();
        public void AddListener(Action listener) => BaseEvent += listener;
        public void RemoveListener(Action listener) => BaseEvent -= listener;
    }
    
    public class EventController<T>
    {
        public event Action<T> BaseEvent;
        public void InvokeEvent(T type) => BaseEvent?.Invoke(type);
        public void AddListener(Action<T> listener) => BaseEvent += listener;
        public void RemoveListener(Action<T> listener) => BaseEvent -= listener;
    }
    
    public class EventController<T, T2>
    {
        public event Action<T, T2> BaseEvent;
        public void InvokeEvent(T type, T2 type2) => BaseEvent?.Invoke(type, type2);
        public void AddListener(Action<T, T2> listener) => BaseEvent += listener;
        public void RemoveListener(Action<T, T2> listener) => BaseEvent -= listener;
    }
}
