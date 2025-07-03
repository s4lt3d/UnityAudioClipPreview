#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(AudioClip), true)]
public class AudioClipPreviewDrawer : PropertyDrawer
{
    private static class AudioUtil
    {
        private static readonly Type t =
            typeof(AudioImporter).Assembly.GetType("UnityEditor.AudioUtil");

        private static readonly MethodInfo play;
        private static readonly MethodInfo stopClip;
        private static readonly MethodInfo stopAllClips;

        private static readonly List<AudioClip> playing = new();

        static AudioUtil()
        {
            if (t == null)
                return;
            
            // check for multiple names as unity changes api function names in new versions of unity. =( 
            foreach (var m in t.GetMethods(BindingFlags.Static |
                                           BindingFlags.Public |
                                           BindingFlags.NonPublic))
            {
                if ((m.Name == "PlayClip" || m.Name == "PlayPreviewClip") &&
                    m.GetParameters().Length > 0 &&
                    m.GetParameters()[0].ParameterType == typeof(AudioClip))
                    play = m;

                if ((m.Name == "StopClip" || m.Name == "StopPreviewClip") &&
                    m.GetParameters().Length == 1)
                    stopClip = m;

                if ((m.Name == "StopAllPreviewClips" || m.Name == "StopAllClips") &&
                    m.GetParameters().Length == 0)
                    stopAllClips = m;
            }
        }

        public static void Play(AudioClip clip)
        {
            StopAll();

            if (play == null || clip == null)
                return;

            var p = play.GetParameters().Length;
            if (p == 1)
                play.Invoke(null, new object[] { clip });
            else if (p == 3)
                play.Invoke(null, new object[] { clip, 0, false });
            else if (p == 4)
                play.Invoke(null, new object[] { clip, 0, false, false });

            playing.Add(clip);
        }

        public static void StopAll()
        {
            if (stopAllClips != null)
            {
                stopAllClips.Invoke(null, null);
                playing.Clear();
                return;
            }

            foreach (var clip in playing)
                stopClip?.Invoke(null, new object[] { clip });

            playing.Clear();
        }
    }

    public override void OnGUI(Rect pos, SerializedProperty prop, GUIContent label)
    {
        var fieldRect = new Rect(pos.x, pos.y, pos.width - 48, pos.height);
        var playRect = new Rect(pos.x + pos.width - 46, pos.y, 22, pos.height);
        var stopRect = new Rect(pos.x + pos.width - 23, pos.y, 22, pos.height);

        EditorGUI.ObjectField(fieldRect, prop, label);

        if (prop.objectReferenceValue is AudioClip clip)
        {
            if (GUI.Button(playRect, "▶"))
                AudioUtil.Play(clip);
            if (GUI.Button(stopRect, "■"))
                AudioUtil.StopAll();
        }
    }
}
#endif
