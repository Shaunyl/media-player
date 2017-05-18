using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Linq;
using System.Configuration;

using Shauni.Database;
using Plugin;
using Shauni.Forms;

namespace Shauni
{
    internal sealed class PluginManager : IPluginProxy
    {
        private MainForm _mainForm = null;

        /// <summary>
        /// Dictionary that contains instances of assemblies for loaded plugins
        /// </summary>
        public Dictionary<Assembly, Plugin.IPlugin> Plugins { get; private set; }

        public PluginManager(MainForm mainform)
        {
            Plugins = new Dictionary<Assembly, Plugin.IPlugin>();
            this._mainForm = mainform;
            this.Load();
        }

        private void Load()
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetCallingAssembly().Location), Paths.Plugins);
            if (!Directory.Exists(path))
                SharedData.Logger.Append(String.Format("Directory {0} not found. Plugins haven't been loaded!", Paths.Plugins), 1);
            else
            {
                try
                {
                    foreach (FileInfo f in new DirectoryInfo(path).GetFiles("*.dll"))
                        if (!LoadPlugin(Path.Combine(path, f.Name)))
                            SharedData.Logger.Append("Can't load the Plugin: " + f.Name, 1);
                }
                catch (System.Security.SecurityException)
                {
                    SharedData.Logger.Append("Can't get access to the directory: " + Paths.Plugins, 1);
                }
            }
        }

        /// <summary>
        /// Loads a plugin
        /// </summary>
        /// <param name="FullName">Full path to a plugin's file</param>
        /// <returns>"true" after successful loading, else "false"</returns>
        public bool LoadPlugin(string FullName)
        {
            Assembly pluginAssembly;
            try
            {
                pluginAssembly = Assembly.LoadFile(FullName);
            }
            catch (Exception ex)  // Can't load the assembly's file
            {
                SharedData.Logger.Append(ex.Message, 1);
                return false;
            }
            try
            {
                Type t = pluginAssembly.GetTypes().FirstOrDefault(x => x.BaseType == typeof(Plugin.IPlugin));

                Plugin.IPlugin plugin = (Plugin.IPlugin)Activator.CreateInstance(t);
                Plugins.Add(pluginAssembly, plugin);
                plugin.Host = this;

                SharedData.Logger.Append(String.Format("Plugin '{0}' has been loaded successfully.", plugin.Name, plugin.Description), 0);

                try
                {
                    plugin.Configuration =
                        (Plugin.ConfigurationBase)typeof(Plugin.ConfigurationBase)
                        .GetMethod("Open").MakeGenericMethod(pluginAssembly.GetTypes()
                        .FirstOrDefault(x => x.BaseType == typeof(Plugin.ConfigurationBase)))
                        .Invoke(null, new object[] { System.IO.Path.GetFileNameWithoutExtension(FullName), 
                              Assembly.GetCallingAssembly().Location });

                }
                // There is not a configuration section's class in the plugin or an error occured during its loading.
                catch (Exception ex)
                {
                    SharedData.Logger.Append(String.Format("Can't load configuration for the Plugin {0}: {1}", pluginAssembly.GetName().Name, ex.Message), 1);
                    // Working with default configuration
                }
                return true;
            }
            catch (Exception ex)
            {
                SharedData.Logger.Append(ex.Message, 1);
                return false;
            }
        }

        /// <summary>
        /// Unloads a plugin. It just removes the plugin from the dictionary and doesn't unload the assembly from the AppDomain. 
        /// </summary>
        /// <param name="Name">Plugin's assembly full name</param>
        public void UnloadPlugin(string Name)
        {
            try
            {
                Plugins.Remove(Plugins.Keys.FirstOrDefault(x => x.FullName == Name));
            }
            catch
            {
                SharedData.Logger.Append(String.Format("Can't unload plugin {0}", Name), 1);
            }
        }

        private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            return Plugins.Keys.FirstOrDefault(x => x.FullName == args.Name);
        }

        object IPluginProxy.MainHandler
        {
            get { return this._mainForm; }
        }
    }
}
