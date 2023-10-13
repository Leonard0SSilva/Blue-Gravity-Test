using System;

[Serializable]
public class Reference { }

[Serializable]
public class Reference<T> : Reference
{
    public bool useConstant = true;
    public T constantValue;
    public Action<T> onValueChange;

    public Variable variable;

    public Reference() { }

    public Reference(T value)
    {
        useConstant = true;
        constantValue = value;
    }

    public virtual T Value
    {
        get { return useConstant ? constantValue : variable.GetValue<T>(); }
    }

    public static implicit operator T(Reference<T> reference)
    {
        return reference.Value;
    }

    public string GetName
    {
        get { return useConstant ? "Local Variable" : variable.name; }
    }
}