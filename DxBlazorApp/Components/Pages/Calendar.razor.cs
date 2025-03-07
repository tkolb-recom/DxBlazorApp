using DevExpress.Blazor;
using DxBlazorApp.Data;
using Microsoft.AspNetCore.Components;

namespace DxBlazorApp.Components.Pages;

public partial class Calendar : ComponentBase
{
    [Inject] private CalendarService CalendarService { get; set; }

    private CalendarEntry[]? _entries = null;

    private DxWindow _windowRef;
    bool _windowVisible;

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

    private void OpenUploadWindow()
    {
        if (_windowVisible)
            _windowRef.CloseAsync();
        else
            _windowRef.ShowAsync();
    }


    protected void SelectedFilesChanged(IEnumerable<UploadFileInfo> files)
    {
        UploadVisible = files.ToList().Count > 0;
        InvokeAsync(StateHasChanged);
    }

    public bool UploadVisible { get; set; }

    protected async Task OnFilesUploading(FilesUploadingEventArgs args)
    {
        var file = args.Files[0];

        await ImportCalendar(file);
    }

    private static async Task ImportCalendar(IFileInputSelectedFile file)
    {
        try
        {
            using var stream = new System.IO.MemoryStream();
            await file.OpenReadStream(file.Size).CopyToAsync(stream);

            stream.Seek(0, System.IO.SeekOrigin.Begin);
            Ical.Net.Calendar calendar = Ical.Net.Calendar.Load(stream);
        }
        catch (Exception ex)
        {
        }
    }
}