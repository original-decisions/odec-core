using odec.Framework.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;



namespace odec.Framework.Infrastructure
{
    /// <summary>
    /// Utility to search the Dlls.
    /// </summary>
    public static class SearchUtils
    {
        private static readonly IList<string> CommonDllLookupDirectories = new List<string>();

        static SearchUtils()
        {
            try
            {
                var entryAssembly = Assembly.GetEntryAssembly();
                var location = entryAssembly.Location;

                var directory = Path.GetDirectoryName(location);
                CommonDllLookupDirectories.Add(directory);
                CommonDllLookupDirectories.Add(Directory.GetCurrentDirectory());
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

        public static string LookupCommonAssemblyStores(string name, IList<string> additionalLookup = null)
        {
            var testDirs = new List<string>();
            testDirs.AddRange(CommonDllLookupDirectories);
            if (additionalLookup != null && additionalLookup.Any())
                testDirs.AddRange(additionalLookup);
            for (int i = 0; i < testDirs.Count; i++)
            {
                var targetPath = Path.Combine(testDirs[i], name);
                if (File.Exists(targetPath)) return targetPath;
            }

            return null;
            //var entryAssembly = Assembly.GetEntryAssembly();
            //var location = entryAssembly.Location;

            //var directory = Path.GetDirectoryName(location);
            //var targetPath = Path.Combine(directory, name);
            //// Lookup working directory
            //if (!File.Exists(targetPath))
            //{
            //    directory = Directory.GetCurrentDirectory();
            //    targetPath = Path.Combine(directory, name);
            //}
        }

        /// <summary>
        /// Returns directory where all fileNames are present
        /// </summary>
        /// <param name="names">checks the filename</param>
        /// <returns></returns>
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
