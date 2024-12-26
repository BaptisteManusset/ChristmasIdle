using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using UnityEngine;

[ExecuteInEditMode]
public class TheUltimateBugFinder : MonoBehaviour
{
    void Awake()
    {
        // Change the numbers here roughly include your faulty instance id
        for (int i = 80500; i < 81000; i++)
        {
            Check(-i);
        }
    }

    private void Check(int id)
    {
#if UNITY_EDITOR
        Object obj = UnityEditor.EditorUtility.InstanceIDToObject(id);
        if (!obj)
            Debug.LogWarning(id + " No object could be found with instance id");
        else
        {
            Debug.Log(id + " Object's name: " + obj.name + "\nToString: " + obj.ToString() 
                      + "\nType: " + obj.GetType().ToString());

            // This part is specific to my case, so I can print all properties of the Sprite that caused my build to fail.
            if(obj is Sprite)
            {
                var sprite = obj as Sprite;
                PropertyInfo[] pi = sprite.GetType().GetProperties();
                var print = "";
                foreach (PropertyInfo p in pi)
                {
                    print += p.Name + " : " + p.GetValue(obj) + "\n";
                }
                Debug.Log(print);
            }

        }
#endif
    }
}