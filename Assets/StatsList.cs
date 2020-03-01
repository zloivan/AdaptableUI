using UnityEngine;

internal class StatsList : Bindable<Stats>
{
    public override void Bind(Stats t)
    {
        //mylogs Probably remove this later
        if (Debug.isDebugBuild) Debug.Log($"<color=purple>Some implementation</color>");

    }
}