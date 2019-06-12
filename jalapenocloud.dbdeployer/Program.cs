using System;
using System.IO;
using JalapenoCloud.Common.Helpers;

namespace JalapenoCloud.DbDeployer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var deployer = new DbDeployer();
                deployer.Deploy();
                deployer.PostDeployment(Path.Combine(Environment.CurrentDirectory, "PostDeploymentScripts"));
                deployer.DeployTestData();

                Console.Write("DONE.");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ExceptionHelper.GetExceptionMessages(ex));
                Console.ReadKey();
            }
        }
    }
}