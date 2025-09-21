using System;

public class List
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }

    //Navigation
    public ICollection<Task> Tasks { get; } = new List<Task>();
}
