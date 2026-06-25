using UnityEngine;

public abstract class ActionDetails : ScriptableObject
{
    public Sprite sprite;
    public Color backgroundColor;

    public int minLuck;
    public int maxLuck;

    public abstract void Act(int luckFactor);
}
