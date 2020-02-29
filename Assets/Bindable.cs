using UnityEngine;

internal abstract class Bindable<T> : MonoBehaviour
{
    public abstract void Bind(T t);
}