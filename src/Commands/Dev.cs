using Discord;
using Discord.Interactions;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace Test.Commands;

public class Asd
{
	[BsonId]
	public string Id { get; set; }

	[BsonElement("count")]
	public int Count { get; set; }
}

[Group("dev", "[Dev] Developer commands")]
[RequireOwner]
public class Dev : InteractionModuleBase
{
	[SlashCommand("test", "[DEV] Testing")]
	public async Task Test() =>
		await RespondAsync(
			Context.User.Mention,
			allowedMentions: AllowedMentions.None);

	[SlashCommand("count", "[DEV] Counting with MongoDB")]
	public async Task Count()
	{
		await DeferAsync();
		MongoClient dbClient = new("mongodb://db");
		var collection = dbClient.GetDatabase("test").GetCollection<Asd>("asd");
		if (!collection.AsQueryable().Any())
			await collection.InsertOneAsync(new Asd { Id = "asd", Count = 0 });
		int count = ++collection.AsQueryable().First().Count;
		await collection.ReplaceOneAsync(x => x.Id == "asd", new Asd { Id = "asd", Count = count });
		await FollowupAsync($"Count: {count}");
	}
}
