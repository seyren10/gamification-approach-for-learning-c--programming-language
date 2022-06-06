using RoslynCSharp;

public class CodeDomain
{
    private ScriptDomain domain = null;
    public void Init()
    {
        bool initCompiler = true;
        domain = ScriptDomain.CreateDomain("MyDomain1", initCompiler);
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

                //run code
                instance.Init();

            }





    }
}
