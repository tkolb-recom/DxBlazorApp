using DxBlazorApp.Data;
using Microsoft.AspNetCore.Components;

namespace DxBlazorApp.Components.Pages;

public partial class Calendar : ComponentBase
{
    private CalendarEntry[]? _entries = null;
    public DateTime Begin { get; set; } = DateTime.Today;
    public DateTime End { get; set; } = DateTime.Today.AddDays(1);

    protected override async Task OnInitializedAsync()
    {
        await this.LoadEntries();
    }

    private async Task LoadEntries()
    {
        _entries = await this.CalendarService.GetEntriesAsync(DateOnly.FromDateTime(DateTime.Now));
    }

    private void SaveEntry()
    {
        CalendarService.AddEntry(this.Begin, this.End); 
        _ = this.LoadEntries();
    }
}