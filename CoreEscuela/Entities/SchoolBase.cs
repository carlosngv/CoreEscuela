using System;
namespace CoreEscuela.Entities
{
    public abstract class SchoolBase
    {
        public string UniqueID { get; private set; }
        public string Name { get; set; }

        public SchoolBase() => UniqueID = Guid.NewGuid().ToString();

        public override string ToString()
        {
            return $"{Name}, {UniqueID}";
        }
    }
}

