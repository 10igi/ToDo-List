using System;

public class Tag
{
	public int Id { get; set; }
	public string Name { get; set; }

    //Navigation
    public virtual Task Task { get; set; }
}
