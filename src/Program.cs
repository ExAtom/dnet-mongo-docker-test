namespace Test;

public class Program
{
	public static void Main() =>
		new Test("config.json")
			.MainAsync().GetAwaiter().GetResult();

	private Program() { }
}
