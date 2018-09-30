/*
 * Author: Dorma Okulo
*/

using UnityEngine;
using System.Collections;

/// <summary>
/// A Generic singleton class powered by Unity's MonoBehaviour.
/// 
/// Override Initiate() instead of using Awake() for things that should
/// run before Start().
/// -Dorma
/// </summary>

public abstract class MonoSingleton<T> : MonoBehaviour where T : Component {
	#region Constants
	private const string
		NAME_PREFIX = "Singleton(",
		NAME_SUFFIX = ")";
	#endregion

	#region Members
	private static T _instance = null;
	private static bool _isExiting = false;
	#endregion

	#region Properties
	/// <summary>
	/// Get the current singleton instance.
	/// </summary>
	/// <value>The instance.</value>
	public static T Instance {
		get{
			if (_instance != null)
				return _instance;
			else if (_instance == null && !_isExiting) {
				_instance = CreateInstance();
				Debug.LogWarning("Created " + _instance.name + " as none was detected.");
				return _instance;
			}
			return null;
		}
	}
	#endregion

	#region MonoBehaviour
	private void Awake() {
		VerifySingleton();
		DontDestroyOnLoad(gameObject);
		Initiate();
	}

	private void OnApplicationQuit() {
		_isExiting = true;
	}
	#endregion

	/// <summary>
	/// Initiate this instance. Use this in favor of Awake().
	/// </summary>
	protected abstract void Initiate();

	#region Creation
	/// <summary>
	/// Creates an instance of the singleton.
	/// </summary>
	/// <returns>The instance.</returns>
	private static T CreateInstance() {
		string tObjName = NAME_PREFIX + typeof(T).Name + NAME_SUFFIX;

		// Check if, for any reason, the GameObject of this name exists and create
		// a new one if not. Recycle the found instance if so.
		// This way, the singleton can't be uninitialized and initialized to 
		// create endless copies of GameObjects.
		GameObject tNewSingleton = GameObject.Find(tObjName);
		if (tNewSingleton == null)
			tNewSingleton = new GameObject(tObjName);

		T tInstance = tNewSingleton.AddComponent<T>();
		return tInstance;
	}
	#endregion

	#region Verification
	/// <summary>
	/// Verifies the singleton.
	/// </summary>
	/// <returns><c>true</c>, if this is the singleton, <c>false</c> if error.</returns>
	protected bool VerifySingleton() {
		// Kill self if a singleton is already established
		if (_instance != null) {
			Destroy(gameObject);
			return false;
		}

		T[] tInstances = FindObjectsOfType<T>();

		// Not sure which instance should be the singleton.
		if (tInstances.Length > 1 && _instance == null) {
			Debug.LogError("Multiple instances of a singleton detected, not sure which to set reference.",this);
			Debug.Break();
		}

		// I am the singleton
		if (tInstances.Length == 1 && _instance == null) {
			_instance = this as T;
			return true;
		}

		return false;
	}
	#endregion

	#region Unloading
	/// <summary>
	/// Unloads the singleton.
	/// </summary>
	public void UnloadSingleton() {
		UnloadSingleton(true, false);
	}

	/// <summary>
	/// Unloads the singleton.
	/// </summary>
	/// <param name="mDestroyComponent">If set to <c>true</c> destroys the component.</param>
	public void UnloadSingleton(bool mDestroyComponent) {
		UnloadSingleton(mDestroyComponent,false);
	}

	/// <summary>
	/// Unloads the singleton.
	/// </summary>
	/// <param name="mDestroyComponent">If set to <c>true</c> destroys the component.</param>
	/// <param name="mDestroyObject">If set to <c>true</c> destroys the GameObject.</param>
	public void UnloadSingleton(bool mDestroyComponent, bool mDestroyObject) {
		string tMsg = (mDestroyObject & mDestroyComponent)
			? name + " reference was unloaded and destroyed."
			: name + " reference was unloaded.";
		Debug.Log (tMsg);
		_instance = null;

		if (mDestroyComponent)
			Destroy(this);
		if (mDestroyObject)
			Destroy(gameObject);
	}
	#endregion
}