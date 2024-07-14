using Serilog;
using Serilog.Sinks.MSSqlServer;

string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs/ATKDotNetCore.MvcChartApp.log");

Log.Logger = new LoggerConfiguration()
	.WriteTo.Console()
	.WriteTo.File(filePath, rollingInterval: RollingInterval.Hour)
	.WriteTo
	.MSSqlServer(
		connectionString: "Server=.;Database=ATKDotNetCore;User ID=sa;Password=sa@123;TrustServerCertificate=True;",
		sinkOptions: new MSSqlServerSinkOptions
		{
			TableName = "Tbl_LogEvents",
			AutoCreateSqlTable = true,
		})
	.CreateLogger();

try
{
	var builder = WebApplication.CreateBuilder(args);
	builder.Services.AddSerilog(); // <-- Add this line

	// Add services to the container.
	builder.Services.AddControllersWithViews();

	var app = builder.Build();

	// Configure the HTTP request pipeline.
	if (!app.Environment.IsDevelopment())
	{
		app.UseExceptionHandler("/Home/Error");
		// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
		app.UseHsts();
	}

	app.UseHttpsRedirection();
	app.UseStaticFiles();

	app.UseRouting();

	app.UseAuthorization();

	app.MapControllerRoute(
		name: "default",
		pattern: "{controller=Home}/{action=Index}/{id?}");

	app.Run();
}
catch (Exception ex)
{
	Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
	Log.CloseAndFlush();
}

