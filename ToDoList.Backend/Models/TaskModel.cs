using System;

public class Task
{
	public int Id { get; set; }
	public string Text { get; set; }
	public bool IsComplete { get; set; }
	public string Description { get; set; }

    //ForeignKey
	public int ListId { get; set; }
	public int TagId { get; set; }

    //Navigation
    public virtual ICollection<Subtask> Subtask{ get; set; }
    public virtual List List { get; set; }
}
