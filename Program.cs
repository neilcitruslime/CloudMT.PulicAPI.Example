namespace CloudMT.PublicAPI.Example;

using CloudMT.PublicAPI.Example.Interfaces;
using CloudMT.PublicAPI.Example.Models;
using CloudMT.PublicAPI.Example.Services;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CloudMT.PublicAPI.Example.Extensions;
using CsvHelper;

internal static class Program
{
    private const string GET_ITEMS = "Get items";
    private const string GET_CATEGORIES = "Get categories";

    internal static async Task Main(string[] args)
    {
        ServiceCollection services = new();

        services.AddHttpClient<IRequestService, RequestService>();

        ServiceProvider serviceProvider = services.BuildServiceProvider();

        IRequestService requestService = serviceProvider.GetRequiredService<IRequestService>();

        string token = await PerformAuthAsync(requestService, args);

        if (string.IsNullOrWhiteSpace(token))
        {
            return;
        }

        do
        {
            SelectionPrompt<string> prompt = new SelectionPrompt<string>()
                .Title("Select request:")
                .AddChoices([GET_ITEMS, GET_CATEGORIES]);

            switch (AnsiConsole.Prompt(prompt))
            {
                case GET_ITEMS:
                    await GetItemsAsync(requestService, token);
                    break;
                case GET_CATEGORIES:
                    await GetCategoriesAsync(requestService, token);
                    break;
            }

            AnsiConsole.Markup("Press Esc to exit or any other key to perform another request...");
        } while (Console.ReadKey().Key != ConsoleKey.Escape);
    }

    private static async Task<string> PerformAuthAsync(IRequestService requestService, string[] strings)
    {
        AuthRequest request;
        if (strings.Length == 2)
        {
            request = new() {Username = strings[0], Password = strings[1]};
        }
        else
        {
            string username = AnsiConsole.Prompt(new TextPrompt<string>("Username:")
                                                     .PromptStyle("green1"));
            string password = AnsiConsole.Prompt(new TextPrompt<string>("Password:")
                                                     .PromptStyle("green1")
                                                     .Secret());

            request = new() {Username = username, Password = password};
        }

        string? token = await requestService.PerformAuthAsync(request, CancellationToken.None);

        if (token is null)
        {
            WriteError("Could not retrieve token using provided username & password.");
            return string.Empty;
        }

        await WaitAsync();

        return token;
    }

    private static async Task GetItemsAsync(IRequestService requestService, string token)
    {
        List<int>? itemKeys = await requestService.GetItemKeysAsync(token, CancellationToken.None);

        if (itemKeys is null)
        {
            WriteError("Could not retrieve item keys.");
            return;
        }

        await WaitAsync();

        List<List<int>> itemKeyBatches = itemKeys.ChunkBy(100);

        List<CsvModel> records = new();
        foreach (List<int> itemKeyBatch in itemKeyBatches)
        {
            ItemsRequest itemsRequest = new()
            {
                Keys = itemKeyBatch
                    .ToList(),
            };

            List<ItemResult>? items = await requestService.GetItemsAsync(token, itemsRequest, CancellationToken.None);

            if (items is null)
            {
                WriteError("Could not retrieve items.");
            }
            else
            {
                foreach (ItemResult item in items)
                {
                    AnsiConsole.WriteLine($"{item.LookupCode}, {item.Name}, {item.Active}");
                    records.Add(new CsvModel() {Id = item.Id, LookupCode = item.LookupCode, Name = item.Name, Active = Convert.ToBoolean(item.Active)});
                }
            }
        }

        string csvFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"items.csv");
        
        using (StreamWriter writer = new(csvFilePath))
        using (CsvWriter csv = new(writer, CultureInfo.InvariantCulture))
        {
            await csv.WriteRecordsAsync(records);
        }
        
        Console.WriteLine($"File saved to '{csvFilePath}'");
    }

    private static async Task GetCategoriesAsync(IRequestService requestService, string token)
    {
        List<CategoryResult>? categories = await requestService.GetCategoriesAsync(token, CancellationToken.None);

        if (categories is null)
        {
            WriteError("Could not retrieve items.");
        }
        else
        {
            foreach (CategoryResult category in categories)
            {
                AnsiConsole.WriteLine(category.ToString());
            }
        }
    }

    private static void WriteError(string message)
    {
        AnsiConsole.MarkupLine($"[red]{message}[/]");
    }

    private static async Task WaitAsync()
    {
        await AnsiConsole.Progress().StartAsync(async context =>
        {
            ProgressTask task = context.AddTask("Loading...");

            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(100);

                task.Increment(10);
            }
        });
    }
}