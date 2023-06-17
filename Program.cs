using pinger;

PingService pingService = new PingService();
var responce = pingService.SendPing();
Console.WriteLine(responce);