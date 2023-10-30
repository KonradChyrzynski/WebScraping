using WebScraping.Interfaces;
using WebScraping.ScrapingServices;

var builder = WebApplication.CreateBuilder(args);


var urls = new string[] {
    "https://www.investing.com/equities/microsoft-corp",
    "https://www.investing.com/equities/tesla-motors",
    "https://www.investing.com/equities/mcgraw-hill-earnings",
    "https://m.investing.com/crypto/bitcoin",
    "https://www.investing.com/crypto/bnb",
    "https://www.investing.com/crypto/ethereum",
};

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<IGetHtmlElementsService>(new AgilityPackScraperService(urls));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();