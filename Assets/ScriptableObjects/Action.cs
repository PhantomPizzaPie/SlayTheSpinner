using UnityEngine;

public abstract class Action : ScriptableObject
{
    public Sprite sprite;
    public Color backgroundColor;
    public abstract void Act();
}
