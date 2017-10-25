using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Utils
{
    public static class ResourcesManager
    {
        private static List<ResourceData> _cachedResources = new List<ResourceData>();
        
        public static T Load<T>(string path, bool cached = false) where T : Object
        {
            var cachedResource = _cachedResources.FirstOrDefault(c => c.Path == path);
            if (cachedResource != null)
                return cachedResource.Resource as T;
            
            var file = Resources.Load<T>(path);
            if(cached)
                _cachedResources.Add(new ResourceData(path, (Object)file, typeof(T)));

            return file;
        }

        public static void ClearCached()
        {
            _cachedResources.Clear();
        }

        #region > Private

        private class ResourceData
        {
            public string Path;
            public Object Resource;
            public Type Type;

            public ResourceData(string path, Object resource, Type type)
            {
                Path = path;
                Resource = resource;
                Type = type;
            }
        }
        
        #endregion
    }
}