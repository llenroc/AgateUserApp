using System;
using System.IO;
using System.Threading.Tasks;

namespace Agate.Business.LocalData
{
    public class FilesFacade
    {
        public static string storagepath(string filename) => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), filename);

        public static Task<bool> Exists(string filename)
        {
            return Task.Run(()=> System.IO.File.Exists(storagepath(filename)));

            //var storage = StorageEverywhere.FileSystem.Current.LocalStorage;
            //var existence = await storage.CheckExistsAsync(filename);
            //if (existence == StorageEverywhere.ExistenceCheckResult.FileExists)
            //    return true;
            //else
            //    return false;
        }

        public static Task<string> ReadFile(string filename)
        {
            filename = storagepath(filename);
            return Task.Run(() =>
            {
                if (File.Exists(filename))
                    return System.IO.File.ReadAllText(filename);
                else
                    return null;
            });
            //var storage = StorageEverywhere.FileSystem.Current.LocalStorage;
            //var existence = await storage.CheckExistsAsync(filename);
            //if (existence == StorageEverywhere.ExistenceCheckResult.FileExists)
            //{
            //    var file = await storage.GetFileAsync(filename);
            //    using (var stream = await file.OpenAsync(StorageEverywhere.FileAccess.Read))
            //    {
            //        using (var reader = new StreamReader(stream))
            //        {
            //            return reader.ReadToEnd();
            //        }
            //    }
            //}
            //return null;
        }

        public static Task SaveFile(string filename, string content, bool overrideExisting = true)
        {
            return Task.Run(() => System.IO.File.WriteAllText(storagepath(filename), content));
            //var storage = StorageEverywhere.FileSystem.Current.LocalStorage;
            //var overrideExistingChoice = overrideExisting ? StorageEverywhere.CreationCollisionOption.ReplaceExisting : StorageEverywhere.CreationCollisionOption.FailIfExists;
            //var file = await storage.CreateFileAsync(filename, overrideExistingChoice);
            //using (var stream = await file.OpenAsync(StorageEverywhere.FileAccess.ReadAndWrite))
            //{
            //    using (var writer = new StreamWriter(stream))
            //    {
            //        writer.Write(content);
            //    }
            //}
        }

        public static Task DeleteFile(string filename)
        {
            return Task.Run(() => System.IO.File.Delete(storagepath(filename)));
            //var storage = StorageEverywhere.FileSystem.Current.LocalStorage;
            //var file = await storage.GetFileAsync(filename);
            //await file.DeleteAsync();
        }

        public static async Task<T> ReadObject<T>(string filename)
        {
            var content = await ReadFile(filename);
            if (content == null)
                return default(T);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(content);
        }

        public static async Task SaveObject<T>(string filename, T obj, bool overrideExisting = true)
        {
            var content = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            await SaveFile(filename, content, overrideExisting);
        }

        public static async Task UpdateObject<T>(string filename, Action<T> updateAction, Func<T> createIfMissing = null)
        {
            var obj = await ReadObject<T>(filename);
            if (obj == null)
            {
                obj = createIfMissing();
            }
            updateAction(obj);
            await SaveObject(filename, obj);
        }

    }
}
