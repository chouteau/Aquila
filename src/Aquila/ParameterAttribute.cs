using System;

namespace Aquila
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    internal class ParameterAttribute : Attribute
    {
        public ParameterAttribute(string name, int maxLength = 0)
        {
            this.ParameterName = name;
            this.MaxLength = maxLength;
        }

        public string ParameterName { get; set; }

        public int MaxLength { get; set; }
    }
}