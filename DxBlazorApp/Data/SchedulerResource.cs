namespace DxBlazorApp.Data;

public class SchedulerResource
{
    public int Id { get; set; }
    public string Name { get; set; }

    public override bool Equals(object obj)
    {
        SchedulerResource resource = obj as SchedulerResource;
        return resource != null && resource.Id == Id;
    }

    public override int GetHashCode()
    {
        return Id;
    }
}