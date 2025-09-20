using System;

public class Subtask
{
	public int Id { get; set; }
	public string Text { get; set; }
	public bool IsComplete { get; set; }
	public string Description { get; set; }

	//ForeignKey
	public int TaskId { get; set; }

	//Navigation
    public virtual Task Task { get; set; }
}
