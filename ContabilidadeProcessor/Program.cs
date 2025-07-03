using ContabilidadeProcessor.Services;
using System.Text.Json;

Console.WriteLine("=== Leitor de Lançamentos Contábeis ===\n");

string caminho = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files", "lancamentos.txt");

var reader = new LancamentoReader();
var lancamentos = reader.LerLancamentos(caminho);

// Exibição simples
foreach (var l in lancamentos)
{
    Console.WriteLine($"{l.Data:dd/MM/yyyy} | Conta: {l.Conta} | {l.Historico} | {l.Tipo} R$ {l.Valor:N2}");
}

string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "lancamentos.json");
string json = JsonSerializer.Serialize(lancamentos, new JsonSerializerOptions { WriteIndented = true });
File.WriteAllText(jsonPath, json);

Console.WriteLine("Arquivo JSON com a lista gerado com sucesso. Checar pasta 'Bin'>'Debug'>'Net8.0'");

