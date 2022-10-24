using RoslynCSharp;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CodeDomain
{
    private ScriptDomain domain = null;

    private MonoBehaviour mb; //add monobehavior to use Coroutine
    public void Init()
    {
        bool initCompiler = true;
        domain = ScriptDomain.CreateDomain("MyDomain1", initCompiler);

        mb = GameObject.FindObjectOfType<MonoBehaviour>();
    }


    public void RunCode(string code)
    {
        ScriptAssembly assembly = domain.CompileAndLoadSource(code);
        ScriptType[] types;

        //try catch and if, making sure that there are no null reference exception in error log
        try
        {
            types = assembly.FindAllSubTypesOf<ICodeEditor>();
        }
        catch
        {
            types = null;
        }

        if (types != null)
            foreach (ScriptType type in types)
            {
                // Create a raw instance of our type
                ICodeEditor instance = type.CreateInstanceRaw<ICodeEditor>();


                //adding a delay before running the code to prevent behavior skips
                //e.g when there's no delay, the physics system stop working for a sec
                //that causes player to pass through the collision system
                if (mb != null)
                    mb.StartCoroutine(AddStartDelay(instance, 1f));
            }





    }

    private IEnumerator AddStartDelay(ICodeEditor instance, float delay)
    {

        yield return new WaitForSeconds(delay);
        instance.Init();


        //do auto movement, IDK what im doing >.<
        if (AutoMoveManager.Instance != null)
            AutoMoveManager.Instance.Move();

    }
}
