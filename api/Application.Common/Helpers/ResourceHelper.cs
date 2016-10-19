using App.Common.Configurations;
using System;
using System.IO;
using System.Reflection;
using System.Resources;

namespace App.Common.Helpers
{
    public class ResourceHelper
    {
        private const string RESOURCE_ASSEMBLY_NAME = "Application.Resources";
        public static void ResolveMessage<IPairItemType>(System.Collections.Generic.IList<IPairItemType> items) where IPairItemType : IResourceItem
        {
            foreach (var item in items)
            {
                item.Message = Resolve(item);
            }
        }

        public static string Resolve(IResourceItem item)
        {
            string message = Resolve(item.Key);
            if (item.Params != null && item.Params.Count > 0)
            {
                for (int index = 0; index < item.Params.Count; index++)
                {
                    message = message.Replace("{" + index + "}", item.Params[index]);
                }
            }
            return message;
        }
        //public static string Resolve(string key, bool isResourceKeyAlways = true)
        //{
        //    if (isResourceKeyAlways == false && !isResourceKey(key)) { return key; }
        //    string[] keys = GetResourceKey(key).Split('.');
        //    string baseName = string.Format("{0}.{1}", RESOURCE_ASSEMBLY_NAME, keys[0]);
        //    ResourceManager resourceManager = new ResourceManager(baseName, Assembly.Load(RESOURCE_ASSEMBLY_NAME));
        //    return resourceManager.GetString(keys[1]);
        //}

        //public static bool isResourceKey(string key)
        //{
        //    return !string.IsNullOrWhiteSpace(key) && key.StartsWith(Constants.RESOURCE_KEY);
        //}
        //public static string GetResourceKey(string key)
        //{
        //    return key.Replace(Constants.RESOURCE_KEY, "");
        //}
        public static string Resolve(string key)
        {
            ResourceType type = GetResourceType(key);
            key = GetKeyValue(key, type);
            switch (type) {
                case ResourceType.Resource:
                    return GetResourceContent(key);
                case ResourceType.MailTemplate:
                    return GetMailTemplateContent(key);
                case ResourceType.Text:
                default:
                    return GetTextResourceKey(key);
            }
        }

        private static string GetMailTemplateContent(string key)
        {
            string filePath = Path.Combine(Configuration.Current.Folder.MailTemplate, key);
            return FileHelper.GetContent(filePath);
        }

        private static string GetResourceContent(string key)
        {
            string[] keys = key.Split('.');
            string baseName = string.Format("{0}.{1}", RESOURCE_ASSEMBLY_NAME, keys[0]);
            ResourceManager resourceManager = new ResourceManager(baseName, Assembly.Load(RESOURCE_ASSEMBLY_NAME));
            return resourceManager.GetString(keys[1]);
        }

        private static string GetTextResourceKey(string key)
        {
            return key;
        }

        private static string GetKeyValue(string key, ResourceType type)
        {
            string emptyResourceKey = string.Format(Constants.RESOURCE_KEY_PATTERN, type.ToString(), "");
            return key.Replace(emptyResourceKey, string.Empty);
        }

        private static ResourceType GetResourceType(string key)
        {
            string emptyResourceKey = string.Format(Constants.RESOURCE_KEY_PATTERN,"","");
            if (key.IndexOf(emptyResourceKey) < 0) {
                return ResourceType.Resource;
            }
            string resourceType = key.Substring(0, key.IndexOf(emptyResourceKey));
            return EnumHelper.Convert<ResourceType>(resourceType);
        }

        public static string ToResourceKey(string key, ResourceType type = ResourceType.Resource)
        {
            return string.Format(Constants.RESOURCE_KEY_PATTERN, type.ToString(), key);
        }
    }
}

