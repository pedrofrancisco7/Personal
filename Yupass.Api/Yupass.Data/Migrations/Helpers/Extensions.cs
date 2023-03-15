using Microsoft.EntityFrameworkCore.Migrations;
using System.Reflection;

namespace Yupass.Data.Migrations;

public static class Helpers
{
    static Assembly? ExecutingAssembly;
    private static async Task<string> GetContentAsync(string resourcePath)
    {
        try
        {
            if (ExecutingAssembly == null) { ExecutingAssembly = Assembly.GetExecutingAssembly(); }
            if (ExecutingAssembly == null) { return string.Empty; }

            resourcePath = $"Yupass.Data.{resourcePath}.sql";
            using (var streamReader = new StreamReader(ExecutingAssembly.GetManifestResourceStream(resourcePath)))
            {
                if (streamReader == null) { return string.Empty; }
                var resourceContent = await streamReader.ReadToEndAsync();
                return resourceContent;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
            return string.Empty;
        }
    }


    public static Task<string> GetContentAsync(this Migration migration, string resourcePath)
    {
        return Helpers.GetContentAsync($"{"Migrations"}.{resourcePath}");
    }

    public static string GetDropProcStatment(this Migration migration, string name)
    {
        return $@"
            if exists(select * from sysObjects where Name='{name}' and xType='P') begin
               DROP PROCEDURE dbo.{name};
            end
         ";
    }

    public static async Task<string> GetCreateProcStatment(this Migration migration, string name)
    {
        var statment = await GetContentAsync(migration, $"Procedures.{name}");
        statment = statment.Replace("'", "''");
        statment = $"exec('{statment}')";
        return statment;
    }
}
