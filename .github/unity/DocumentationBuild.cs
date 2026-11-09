using System;
using System.IO;
using UnityEngine;

namespace DocFxTest.CI
{
    // Copied into Assets/Editor by documentation.yml for the Unity invocation only.
    public static class DocumentationBuild
    {
        public static void Prepare()
        {
            // Unity imports packages and compiles scripts before invoking this method.
            string projectRoot = Path.GetDirectoryName(Application.dataPath);
            string assembliesDirectory = Path.Combine(projectRoot, "Library", "ScriptAssemblies");

            foreach (string assembly in new[] { "Unity.InputSystem.dll", "Assembly-CSharp.dll" })
            {
                string assemblyPath = Path.Combine(assembliesDirectory, assembly);
                if (!File.Exists(assemblyPath) || new FileInfo(assemblyPath).Length == 0)
                {
                    throw new InvalidOperationException("Required documentation assembly is missing: " + assemblyPath);
                }
            }

            Debug.Log("Documentation dependencies are ready. No player build was requested.");
        }
    }
}
