using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]
public abstract class IInputHandler : MonoBehaviour
{
	public abstract void UpdateDirectionalInput(float horizontalAxis, float verticalaxis);
	public abstract void OnKeyPressed(KeyCode key);
	public abstract void OnKeyReleased(KeyCode key);
}