using System;
using System.Collections.Generic;
using System.Linq;

public class CircularBuffer<T>
{
    private  int[] _bufferArray;
    private int currentIndex = -1;
    private int currentWriteIndex = 0;
    private int currentStartIndex = 0;
    private int _capacity = 0;
    public CircularBuffer(int capacity)
    {
        
        _bufferArray =Array.Empty<int>();
        _capacity = capacity;
  

    }

    public T Read()
    {
     
        try
        {
            var bufferRead = (T)Convert.ChangeType(_bufferArray[0], typeof(int));

            List<int> _bufferList = _bufferArray.ToList();
            _bufferList.RemoveAt(0);
            _bufferArray = _bufferList.ToArray();
            currentWriteIndex -= 1;

            return bufferRead;
        }
        catch (IndexOutOfRangeException)
        {

            throw new InvalidOperationException();
        }
        catch(Exception ex)
        {
            throw ex;
        }
        
        //.

    }

    public void Write(T value)
    {
        Array.Resize(ref _bufferArray, _capacity);
        try
        { 
            _bufferArray[currentWriteIndex] = (int)Convert.ChangeType(value, typeof(int));
            currentWriteIndex += 1;


        }
        catch (IndexOutOfRangeException)
        {

            throw new InvalidOperationException();
        }
        catch (Exception ex)
        {
            throw ex;
        }


    }

    public void Overwrite(T value)
    {
        int emptyIndex =  Array.IndexOf(_bufferArray, 0);

        if (emptyIndex ==-1)
        {
            Read();
            Write(value);
      
        }
        else
        {
            _bufferArray[emptyIndex] = (int)Convert.ChangeType(value, typeof(int));
           
        }

    }

    public void Clear()
    {
        _bufferArray = Array.Empty<int>();
        currentIndex = -1;
        currentWriteIndex = 0;

    }
}