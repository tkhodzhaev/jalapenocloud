using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using ComfortFramework.Core.FileService;
using ComfortFramework.SystemNotification;
using ServiceStack.OrmLite;

namespace JalapenoCloud.Dal.Logic
{
    public class SqlScriptExecutor
    {
        public void ExecuteScript(string script)
        {
            using (IDbConnection db =
                    OrmLiteConnectionFactoryWrapper.Factory
                    .OpenDbConnection())
            {
                db.ExecuteSql(script);
            }
        }

        public void ExecuteScriptList(List<string> scripts)
        {
            using (IDbConnection db =
                    OrmLiteConnectionFactoryWrapper.Factory
                    .OpenDbConnection())
            {
                foreach (string script in scripts)
                    db.ExecuteSql(script);
            }
        }

        public void ExecuteFileScript(string path)
        {
            try
            {
                if (!File.Exists(path))
                    throw new ArgumentException("File doesn't exist", "path");

                string sql = File.ReadAllText(path);

                if (!string.IsNullOrWhiteSpace(sql))
                    ExecuteScript(sql);
            }
            catch (Exception ex)
            {
                var cfe = new CFException("Error occurred while executing script: " + path, ex);
                throw cfe;
            }
        }

        public void ExecuteAllScriptsInFolder(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                    throw new ArgumentException("Folder doesn't exist", "path");

                List<string> files = FileSearchService.SearchByMasksRecursive(path, new List<string>() { "*.sql" });
                var scripts = new List<string>();

                foreach (string file in files)
                {
                    string sql = File.ReadAllText(file);

                    if (!string.IsNullOrWhiteSpace(sql))
                        scripts.Add(sql);
                }

                ExecuteScriptList(scripts);
            }
            catch (Exception ex)
            {
                var cfe = new CFException("Error occurred while executing scripts contained in folder: " + path, ex);
                throw cfe;
            }
        }
    }
}