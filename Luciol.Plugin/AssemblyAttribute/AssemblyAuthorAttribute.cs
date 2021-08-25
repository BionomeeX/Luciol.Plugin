using System;

namespace Luciol.Plugin.AssemblyAttribute
{
    [AttributeUsage(AttributeTargets.Assembly)]
    public class AssemblyAuthorAttribute : Attribute
    {
        public AssemblyAuthorAttribute(string author)
        {
            Author = author;
        }

        public string Author { private init; get; }
    }
}
