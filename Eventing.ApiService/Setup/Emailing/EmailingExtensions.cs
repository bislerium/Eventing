namespace Eventing.ApiService.Setup.Emailing;

public static class EmailingExtensions
{
    public static void AddXEmailing(this IHostApplicationBuilder builder)
    {
        var smtpSection = builder.Configuration.GetSection("Smtp");
        var senderEmail = smtpSection["SenderEmail"];
        var senderName = smtpSection["SenderName"];
        var host = smtpSection["Host"];
        var port = smtpSection["Port"];
        var username = smtpSection["Username"];
        var password = smtpSection["Password"];

        ArgumentNullException.ThrowIfNull(senderEmail);
        ArgumentNullException.ThrowIfNull(host);
        ArgumentNullException.ThrowIfNull(port);
        ArgumentNullException.ThrowIfNull(username);
        ArgumentNullException.ThrowIfNull(password);

        builder.Services
            .AddFluentEmail(
                defaultFromEmail: senderEmail,
                defaultFromName: senderName)
            .AddSmtpSender(
                host: host,
                port: int.Parse(port),
                username: username,
                password: password);
    }

    public static void AddXTestEmailing(this IHostApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("mailpit");
        ArgumentNullException.ThrowIfNull(connectionString);

        var uri = new Uri(connectionString["Endpoint=".Length..]);
        const string senderEmail = "no-reply@example.com";

        builder.Services
            .AddFluentEmail(defaultFromEmail: senderEmail)
            .AddSmtpSender(
                host: uri.Host,
                port: uri.Port);
    }
}