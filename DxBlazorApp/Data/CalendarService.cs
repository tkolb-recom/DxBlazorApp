using System.Xml.Serialization;

namespace DxBlazorApp.Data;

public class CalendarService
{
    List<CalendarEntry>? _calendarEntries = new();

    public Task<CalendarEntry[]> GetEntriesAsync(DateOnly startDate)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<CalendarEntry>));

        if (File.Exists("calendar.xml"))
        {
            using var stream = new FileStream("calendar.xml", FileMode.Open);
            _calendarEntries = serializer.Deserialize(stream) as List<CalendarEntry>;
        }

        return Task.FromResult(_calendarEntries.ToArray());
    }

    public void Save()
    {
        using var stream = new FileStream("calendar.xml", FileMode.Create);

        XmlSerializer serializer = new XmlSerializer(typeof(List<CalendarEntry>));
        serializer.Serialize(stream, _calendarEntries);
    }

    public void AddEntry(DateTime begin, DateTime end)
    {
        _calendarEntries.Add(new CalendarEntry { Begin = begin, End = end });
        this.Save();
    }
}