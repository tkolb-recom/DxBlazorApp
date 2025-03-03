using DevExpress.Blazor;
using DxBlazorApp.Data;
using Microsoft.AspNetCore.Components;

namespace DxBlazorApp.Components.Pages;

public partial class Overview : ComponentBase
{
    private CalendarEntry[]? _entries = null;

    protected override async Task OnInitializedAsync()
    {
        await this.LoadEntries();
    }

    private async Task LoadEntries()
    {
        _entries = await this.CalendarService.GetEntriesAsync(DateOnly.FromDateTime(DateTime.Now));

        DataStorage = new DxSchedulerDataStorage()
        {
            AppointmentsSource = _entries,
            AppointmentMappings = new DxSchedulerAppointmentMappings()
            {
                Start = nameof(CalendarEntry.Begin),
                End = nameof(CalendarEntry.End)
            },
            // ResourcesSource = ResourceCollection.GetResourcesForGrouping(),
            // ResourceMappings = new DxSchedulerResourceMappings()
            // {
            //     Id = "Id",
            //     Caption = "Name",
            //     BackgroundCssClass = "BackgroundCss",
            //     TextCssClass = "TextCss"
            // }
        };
    }

    DateTime StartDate { get; set; } = DateTimeUtils.GetBeginOfMonth(DateTime.Today);

    private DxSchedulerDataStorage DataStorage = null;

    List<SchedulerResource> VisibleResources = ResourceCollection.GetResources().Take(2).ToList();
}