using System;

namespace Luciol.Plugin
{
    public record Dependency
    {
        public Dependency(Type type, bool isMandatory)
        {
            if (!type.IsSubclassOf(typeof(APluginInfo)))
            {
                throw new ArgumentException($"{nameof(type)} must inherit APluginInfo", nameof(type));
            }
            (Type, IsMandatory) = (type, isMandatory);
        }

        public Type Type { private init; get; }
        public bool IsMandatory { private init; get; }
        public APlugin Plugin { internal set; get; }
    }
}
