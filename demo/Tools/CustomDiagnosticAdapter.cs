using System;
using Microsoft.Extensions.DiagnosticAdapter;

namespace demo.Tools
{
    public class CustomDiagnosticAdapter
    {
        [DiagnosticName("MyEventType")]
        public virtual void OnDiagnostic(string data)
        {
            Console.WriteLine("Przechwyciłem wydarzenie typu MyEventType z komunikatem: "+data);
        }

        [DiagnosticName("Microsoft.AspNetCore.Mvc.BeforeAction")]
        public virtual void OtherFunction(string data)
        {
            Console.WriteLine("Przechwyciłem event typu BeforeAction");
        }
    }
}