using UnityEngine;

public class UIHelper_Example : MonoBehaviour
{
	public static TextMesh mText;

	void Awake()
	{
		//Get TextMesh Component
		mText = GetComponent<TextMesh>();
	}

	public static void ChangeText(string newText)
	{
		//Update Text
		mText.text = newText;
	}
}
