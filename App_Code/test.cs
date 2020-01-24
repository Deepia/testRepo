using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for test
/// </summary>
public class test
{
    public test()
    {
        //
        // TODO: Add constructor logic here
        //
        
            SingletonB.instance.Test();
        
    }
    

        
    
}
class SingletonB
{
    public static readonly SingletonB instance = new SingletonB();

    public void Test()
    {
        // Code runs.
        Console.WriteLine(true);
    }

    SingletonB()
    {
    }
}