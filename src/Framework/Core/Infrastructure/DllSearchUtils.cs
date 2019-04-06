using odec.Framework.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;



namespace odec.Framework.Infrastructure
{
    /// <summary>
    /// Utility to search the Dlls in the common storage places such as Nuget cache, working dir current dir etc..
    /// Current default search dirs are:
    /// <code>Directory.GetCurrentDirectory()</code>
    /// <code>Assembly.GetEntryAssembly().Location</code>
    /// <code>Directory.GetCurrentDirectory()+"\\Libs"</code>
    /// <code>Directory.GetCurrentDirectory()+"\\Libs"</code>
    /// </summary>
    public static class SearchUtils
    {
        /// <summary>
        /// Lookup collection for the directories.
        /// </summary>
        private static readonly IList<string> CommonDllLookupDirectories = new List<string>();

        /// <summary>
        /// Class initializer. It populates the common assembly locations for which we need to search an assembly.
        /// </summary>
        static SearchUtils()
        {
            try
            {
                var entryAssembly = Assembly.GetEntryAssembly();
                var location = entryAssembly.Location;

                var directory = Path.GetDirectoryName(location);
                CommonDllLookupDirectories.Add(directory);
                CommonDllLookupDirectories.Add(Directory.GetCurrentDirectory());
                CommonDllLookupDirectories.Add(Directory.GetCurrentDirectory() + "\\Libs");
                //var RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
                //Nuget package 
                //switch (Assembly.GetEntryAssembly().GetCustomAttribute<TargetFrameworkAttribute>().FrameworkName)
                //{

                //}
            }
            catch (Exception ex)
            {
                LogEventManager.Logger.Error(ex.Message, ex);
                throw;
            }

        }

        /// <summary>
        /// Looks up the dll file by the <paramref name="name"/> provided in the common dll locations
        /// (see below for more info) and adding the custom lookup locations to be checked.
        ///   <example>
        ///     <code>Directory.GetCurrentDirectory()</code>
        ///     <code>Assembly.GetEntryAssembly().Location</code>
        ///     <code>Directory.GetCurrentDirectory()+"\\Libs"</code>
        ///     <code>Directory.GetCurrentDirectory()+"\\Libs"</code>
        ///   </example>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="additionalLookup"></param>
        /// <returns></returns>
        public static string LookupCommonAssemblyStores(string name, IList<string> additionalLookup = null)
        {
            var testDirs = new List<string>();
            testDirs.AddRange(CommonDllLookupDirectories);
            if (additionalLookup != null && additionalLookup.Any())
                testDirs.AddRange(additionalLookup);

            var result = testDirs
                .Select(it => Path.Combine(it, name))
                .FirstOrDefault(File.Exists);

            return result;
        }

        /// <summary>
        /// Returns directory where all fileNames are present
        /// </summary>
        /// <param name="names">File names as <see cref="string"/> collection to be checked in the common dll stores.</param>
        /// <returns>Gives the file full name with the path.</returns>
        public static string CheckCommonAssemblyStoresForFile(IList<string> names)
        {
            if (names == null || !names.Any()) return null;
            var testDirs = new List<string>();
            testDirs.AddRange(CommonDllLookupDirectories);


            var result = CommonDllLookupDirectories.Select(it => new DirectoryInfo(it))
                .First(it =>
                    it.GetFiles()
                    .All(it2 => names.Any(it3 => it.Name == it3)));

            return result?.FullName;
        }
    }
}
