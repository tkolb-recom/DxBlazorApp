namespace DxBlazorApp.Data;

public static partial class ResourceCollection

{
    public static List<SchedulerResource> GetResources()
    {
        return new List<SchedulerResource>()
        {
            new SchedulerResource()
                { Id = 0, Name = "Nancy Davolio" },
            new SchedulerResource()
                { Id = 1, Name = "Andrew Fuller" },
        };
    }
}