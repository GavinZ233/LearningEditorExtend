
using UnityEditor;
using UnityEditor.Compilation;
using UnityEngine;


namespace Gavin
{

	public class Lesson46_CompilationPipeline: EditorWindow
	{
        [MenuItem("Unity编辑器拓展/Lesson46/CompilationPipeline")]
        private static void OpenLesson44()
        {
            Lesson46_CompilationPipeline win = EditorWindow.GetWindow<Lesson46_CompilationPipeline>("CompilationPipeline");
            win.Show();
        }

        private void OnEnable()
        {
            CompilationPipeline.assemblyCompilationFinished += ACF;
            CompilationPipeline.compilationFinished += CF;

        }
        private void OnDestroy()
        {
            CompilationPipeline.assemblyCompilationFinished -= ACF;
            CompilationPipeline.compilationFinished -= CF;

        }
        private void ACF(string name,CompilerMessage[] cm)
        {
            Debug.Log("编译完成："+name);
        }
        private void CF(object obj)
        {
            Debug.Log("所有脚本编译完成");
        }
    }

}
