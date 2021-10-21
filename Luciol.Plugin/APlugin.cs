using Luciol.Plugin.Context;
using Luciol.Plugin.Preference;
using Luciol.Plugin.SaveLoad;
using System.Collections.ObjectModel;

namespace Luciol.Plugin
{
    public abstract class APlugin
    {
        internal virtual void Init(IContext context, APlugin[] dependencies)
        {
            Context = context;
            Dependencies = dependencies;
            Init();
        }

        /// <summary>
        /// Plugins need to do their initialization here instead of the ctor
        /// The reason is that Context is garenteed to be not null in the Init function
        /// </summary>
        protected virtual void Init()
        { }

        /// <summary>
        /// Global context, contains various information about the current program
        /// </summary>
        public IContext Context { protected set; get; }

        /// <summary>
        /// Metadata about the plugin
        /// </summary>
        public APluginInfo PluginInfo { internal set; get; }

        public APlugin[] Dependencies { protected set; get; }

        /// <summary>
        /// Plugin preferences
        /// </summary>
        public ReadOnlyDictionary<string, IPreferenceExport> Preferences { protected set; get; }

        /// <summary>
        /// A plugin can save whatever it wants using this
        /// </summary>
        public ICustomData CustomData
        {
            set
            {
                _customData = value;
                _customData.Init(CustomDataInit);
            }
            get
            {
                return _customData;
            }
        }
        internal object CustomDataInit { set; private get; }
        private ICustomData _customData;
    }
}
