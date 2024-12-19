using System.Reflection;

namespace EatLess.Infrastructure
{
    public class AssemblyReference
    {
        public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
    }
}
