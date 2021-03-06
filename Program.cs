using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration.AzureKeyVault;

namespace Timmy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

          public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((_, config) =>
            {
                var appSettings = config.Build();
                var KVName = appSettings["KeyVaultName"];
                var azureServiceTokenProvider = new AzureServiceTokenProvider();
                
                var keyVaultClient = new KeyVaultClient(
                    new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));

                    //https://learnkvjfv.vault.azure.net/
                    
                    config.AddAzureKeyVault($"https://{appSettings["KeyVaultName"]}.vault.azure.net/",
                    keyVaultClient, new DefaultKeyVaultSecretManager());
            })
            .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Bobo>();
                });

//private static string GetKeyVaultEndpoint() => "https://<VAULT_NAME>.vault.azure.net/";


    //   public static IHostBuilder CreateHostBuilder(string[] args) =>
    //         Host.CreateDefaultBuilder(args)
    //         .ConfigureAppConfiguration((_, config) =>
    //         {
    //             var appSettings = config.Build();
    //             var KVName = appSettings["KeyVaultName"];
    //             var azureServiceTokenProvider = new AzureServiceTokenProvider();
    //             var keyVaultClient = new KeyVaultClient(
    //                 new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));
    //                 //https://learnkvjfv.vault.azure.net/
    //                 config.AddAzureKeyVault($"https://{appSettings["KeyVaultName"]}.vault.azure.net/",
    //                 keyVaultClient, new DefaultKeyVaultSecretManager());
    //         })
    //         .ConfigureWebHostDefaults(webBuilder =>
    //             {
    //                 webBuilder.UseStartup<Bobo>();
    //             });
            
      
      
      
      
        // public static IHostBuilder CreateHostBuilder(string[] args) =>
        //     Host.CreateDefaultBuilder(args)
        //         .ConfigureWebHostDefaults(webBuilder =>
        //         {
        //             webBuilder.UseStartup<Bobo>();
        //         });
    }
}
