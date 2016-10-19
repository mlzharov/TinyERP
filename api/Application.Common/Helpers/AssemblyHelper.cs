using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using App.Common.Tasks;

namespace App.Common.Helpers
{
    public class AssemblyHelper
    {
        public static string GetBinDirectory()
        {
            var binFolderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().EscapedCodeBase).Replace("file:\\", "");
            return binFolderPath;
        }

        public static void ExecuteTasks<TaskType, ContextType>(ContextType context, AssemblyType lookupIn) where TaskType : IBaseTask<ContextType>
        {
            string assemblyName = GetAssemblyNameBaseOnAssemblyType(lookupIn);
            IEnumerable<Type> tasksToRun = GetTypes<TaskType>(assemblyName);
            foreach (var task in tasksToRun)
            {
                TaskType instance = (TaskType)Activator.CreateInstance(task);
                instance.Execute(context);
            }
        }

        public static void ExecuteTasks<TaskType, ContextType>(ContextType context, bool runTasksInOrder = false) where TaskType : IBaseTask<ContextType>
        {
            IEnumerable<Type> tasksToRun = GetTypes<TaskType>();
            if (runTasksInOrder) {
                runTasksInOrder<TaskType, ContextType>(tasksToRun, context);
                return;
            }
            foreach (var task in tasksToRun)
            {
                TaskType instance = (TaskType)Activator.CreateInstance(task);
                instance.Execute(context);
            }
        }
        private static void runTasksInOrder<TaskType, ContextType>(IEnumerable<Type> tasks, ContextType context) where TaskType : IBaseTask<ContextType>
        {
            IList<IBaseTask<ContextType>> taskInstances = new List<IBaseTask<ContextType>>();
            foreach (var task in tasks)
            {
                TaskType instance = (TaskType)Activator.CreateInstance(task);
                taskInstances.Add(instance);
            }
            taskInstances = taskInstances.OrderBy(task => task.Order).ToList();
            foreach (var instance in taskInstances)
            {
                instance.Execute(context);
            }
        }
        public static IEnumerable<Type> GetTypes<ExpectedType>()
        {
            return GetTypes<ExpectedType>(string.Empty);
        }
        public static IEnumerable<Type> GetTypes<ExpectedType>(string filePattern="*.dll")
        {
            filePattern = string.IsNullOrWhiteSpace(filePattern) ? "*.dll" : filePattern;
            IEnumerable<Type> types = new List<Type>();

            /*var binFolderPath = GetBinDirectory();
            IList<string> files =
                Directory.GetFiles(binFolderPath, filePattern)
                    .Where(file => (Path.GetFileNameWithoutExtension(file) ?? "").StartsWith(Constants.APPLICATION_NAMESPACE_START_WITH))
                    .ToList();*/
            IList<string> dlls = GetApplicationDlls(filePattern);
            foreach (string assemblyName in dlls)
            {
                //string assemblyName = Path.GetFileNameWithoutExtension(fileInfo) ?? "";
                var taskInFile = Assembly.Load(assemblyName).GetTypes()
                    .Where(t => !t.IsAbstract && t.IsClass && typeof(ExpectedType).IsAssignableFrom(t)).ToList();
                types = types.Union(taskInFile);
            }
            return types;
        }
        public static IEnumerable<Type> GetAllApplicationTypes(string filePattern = "*.dll")
        {
            IEnumerable<Type> types = new List<Type>();
            IList<string> dlls = GetApplicationDlls(filePattern);
            foreach (string assemblyName in dlls)
            {
                var taskInFile = Assembly.Load(assemblyName).GetTypes()
                    .Where(t => !t.IsAbstract).ToList();
                types = types.Union(taskInFile);
            }
            return types;
        }

        public static IList<string> GetApplicationDlls(string filePattern) {
            var binFolderPath = GetBinDirectory();
            IList<string> files =
                Directory.GetFiles(binFolderPath, filePattern)
                    .Where(file => (Path.GetFileNameWithoutExtension(file) ?? "").StartsWith(Constants.APPLICATION_NAMESPACE_START_WITH))
                    .Select(fileItem => Path.GetFileNameWithoutExtension(fileItem))
                    .ToList();
            return files;
        }
        private static string GetAssemblyNameBaseOnAssemblyType(AssemblyType lookupIn)
        {
            string assemblyName;
            switch (lookupIn)
            {
                case AssemblyType.Common:
                    assemblyName = "App.Common.dll";
                    break;
                case AssemblyType.Context:
                    assemblyName = "App.Context.dll";
                    break;
                case AssemblyType.Repository:
                    assemblyName = "App.Repository.dll";
                    break;
                case AssemblyType.Service:
                    assemblyName = "App.Service.dll";
                    break;
                default:
                    assemblyName = "App.Api.dll";
                    break;
            }
            return assemblyName;
        }
    }
}
