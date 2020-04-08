using System;

namespace SchoolSharp.Entities
{
    public abstract class BaseSchool
    {
        // Abstract means you can only use this class for inheritance (cannot instantiate for example)
        // Sealed (in SchoolEngine) means you can instantiate for example but cannot inherit (it's the opposite)
        public string Name { get; set; }
        public string UniqueId { get; private set; }
        
        public BaseSchool()
        {
            UniqueId = Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            return $"{Name}, {UniqueId}";
        }
    }
}