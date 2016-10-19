using System;
using System.Collections.Generic;
using Omega.Common.Data.Migration;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace Omega.Common.Helpers
{
    public class PowerShellHelper
    {
        public static void UpdateMigration()
        {
            IEnumerable<Type> configurations = AssemblyHelper.GetTypes<IMigrationCofiguration>();
            foreach (var configuration in configurations)
            {
                string className = configuration.FullName;
                string project = configuration.Assembly.ManifestModule.Name.Replace(".dll","");
                RunMigration(project, className);
            }
        }

        private static void RunMigration(string project, string className)
        {
            try
            {
                UpdateDatabase(project, className);
            }
            catch (Exception ex)
            {
                if (ExceptionHelper.IsMigrationPendingChangeException(ex))
                {
                    AddIgnoreChangeMigration(project, className);
                    UpdateDatabase(project, className);
                }
            }
        }

        private static void UpdateDatabase(string project, string className)
        {
            PowerShell ps = GetPowerShellInstance();
            //string importCommand = @"Import-Module D:\projects\Omega.GIT\Omega\packages\EntityFramework.6.1.2\tools\EntityFramework.psm1";
            //string updateCommand = String.Format("Update-Database -ConfigurationTypeName {0} -ProjectName {1}", className, project);
            //string commandToRun = importCommand + " | " + updateCommand;
            ps.AddCommand("Update-Database").AddParameter("-ConfigurationTypeName", className).AddParameter("-ProjectName", project);
            //ps.AddCommand(commandToRun);
            ps.Invoke();
        }
        private static void AddIgnoreChangeMigration(string project, string className)
        {
            PowerShell ps = GetPowerShellInstance();
            ps.AddCommand("add-migration")
                .AddParameter("-ConfigurationTypeName", className)
                .AddParameter("-ProjectName", project)
                .AddParameter("-IgnoreChange", "")
                .AddParameter("-name", "IgnoreChange");
            ps.Invoke();
        }

        private static PowerShell GetPowerShellInstance()
        {
            PowerShell ps = PowerShell.Create();
            //ps.Runspace = RunspaceFactory.CreateRunspace(InitialSessionState.CreateDefault());
            //ps.AddScript(@"D:\projects\Omega.GIT\Omega\packages\EntityFramework.6.1.2\tools\install.ps1");
            //ps.AddScript(@"D:\projects\Omega.GIT\Omega\packages\EntityFramework.6.1.2\tools\init.ps1");
            //ps.AddCommand("Import-Module").AddParameter("Name",@"D:\projects\Omega.GIT\Omega\packages\EntityFramework.6.1.2\tools\EntityFramework.psm1");
            ps.AddScript(@"import-module -Name D:\projects\Omega.GIT\Omega\packages\EntityFramework.6.1.2\tools\EntityFramework.psm1");
            return ps;
        }
    }
}
