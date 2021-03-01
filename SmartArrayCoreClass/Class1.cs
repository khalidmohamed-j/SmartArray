using System;
public class SmartArray
{
    private int[] UnderlyingArray;

    public int Length { get; private set; }

    public bool autoExpand = false;


    public SmartArray(int startSize)
    {
        UnderlyingArray = new int[startSize];
        Length = UnderlyingArray.Length;
    }

    public SmartArray(int startSize, bool _autoExpand)
    {
        UnderlyingArray = new int[startSize];
        Length = UnderlyingArray.Length;
        autoExpand = _autoExpand;
    }


    public void SetAtIndex(int index, int val)
    {
        if (index < 0)
        {
            throw new IndexOutOfRangeException("Provided index is too small.  Min is 0.");
        }
       
        else if (autoExpand == true && (index >= UnderlyingArray.Length && index < UnderlyingArray.Length * 2))
        {
            Resize();
            UnderlyingArray[index] = val;

        }
        else if (autoExpand == true && index >= UnderlyingArray.Length * 2)
        {
            Resize(index + 1);
            UnderlyingArray[index] = val;

        }
        else if (index >= UnderlyingArray.Length)
        {
            throw new IndexOutOfRangeException($"Provided index is too large.  Max value is {UnderlyingArray.Length - 1}");
        }
        else
        {
            UnderlyingArray[index] = val;
        }
    }

    public int GetAtIndex(int index)
    {
        try
        {
            return UnderlyingArray[index];
        }
        catch (Exception)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException("Provided index is too small.  Min is 0.");
            }
            else if (index >= UnderlyingArray.Length)
            {
                throw new IndexOutOfRangeException($"Provided index is too large.  Max value is {UnderlyingArray.Length - 1}");
            }
        }
        return Int32.MinValue;

    }

    public void PrintAllElements()
    {
        Console.WriteLine("\nCurrent Array values:");
        for (int i = 0; i < UnderlyingArray.Length; i++)
        {
            Console.WriteLine(UnderlyingArray[i]);
        }
    }

    public bool Find(int val)
    {
        for (int i = 0; i < UnderlyingArray.Length; i++)
        {
            if (UnderlyingArray[i] == val)
            {
                return true;
            }
        }
        return false;
    }

    public void Resize()
    {
        Resize(UnderlyingArray.Length * 2);
    }
   
    public void Resize(int newSize)
    {
        int[] workArray = new int[newSize];
        int limit = newSize > UnderlyingArray.Length ? UnderlyingArray.Length : newSize;
        for (int i = 0; i < limit; i++)
        {
            workArray[i] = UnderlyingArray[i];
        }
        UnderlyingArray = workArray;
        Length = UnderlyingArray.Length;
    }

    public void Resize(int newSize, bool allowTruncation)
    {
        
        if (allowTruncation == true)
        {
            Resize(UnderlyingArray[newSize]);
            Array.Resize(ref UnderlyingArray, newSize);
        }

        else 
        {
            for (int i = 0; i < UnderlyingArray.Length; i++)
            {
                int lastNumber = UnderlyingArray.Length - 1;
                if (UnderlyingArray[lastNumber] == 0)
                {
                    Array.Resize(ref UnderlyingArray, lastNumber);
                }
            }
        }
    }
}
