using System;
using System.Collections.Generic;
using System.Linq;

public class CircularBuffer<T>
{
  
    private Queue<int> _bufferArray = new Queue<int>();
    private int _capacity = 0;

    public CircularBuffer(int capacity)
    {
        _capacity = capacity;
    }

    public T Read() => (T)Convert.ChangeType(_bufferArray.Dequeue(), typeof(int));

    public void Write(T value)
    {
            if (_bufferArray.Count >= _capacity)
                throw new InvalidOperationException();
       
            _bufferArray.Enqueue((int)Convert.ChangeType(value, typeof(int)));
    }

    public void Overwrite(T value)
    {
        if (_bufferArray.Count == _capacity)
        {
            Read();
            Write(value);
      
        }
        else
        {
            _bufferArray.Enqueue((int)Convert.ChangeType(value, typeof(int)));

        }

    }

    public void Clear() =>_bufferArray.Clear();

   
}