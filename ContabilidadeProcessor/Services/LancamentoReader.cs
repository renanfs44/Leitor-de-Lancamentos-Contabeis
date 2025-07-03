using ContabilidadeProcessor.Models;
using System.Globalization;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ContabilidadeProcessor.Services;

public class LancamentoReader
{
    public List<LancamentoContabil> LerLancamentos(string arquivo)
    {
        List<LancamentoContabil> lancamentos = new List<LancamentoContabil>();

        string caminho = arquivo;
        string[] linhas = File.ReadAllLines(caminho);

        for (int i = 0; i < linhas.Length - 4; i++)
        {
            if (string.IsNullOrWhiteSpace(linhas[i]) || linhas[i].StartsWith("#"))
                continue;

            try
            {
                var bloco = new string[]
                {
            linhas[i].Trim(),
            linhas[i + 1].Trim(),
            linhas[i + 2].Trim(),
            linhas[i + 3].Trim(),
            linhas[i + 4].Trim()
                };
                i += 4;

                var campos = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

                foreach (var linha in bloco)
                {
                    var partes = linha.Split(':', 2);
                    if (partes.Length == 2)
                        campos[partes[0].Trim()] = partes[1].Trim();
                }

                var lancamento = new LancamentoContabil();

                if (campos.TryGetValue("Data", out string dataStr))
                    lancamento.Data = DateTime.ParseExact(dataStr, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                else throw new Exception("Campo 'Data' não encontrado.");

                if (campos.TryGetValue("Conta", out string contaStr))
                    lancamento.Conta = int.Parse(contaStr);
                else throw new Exception("Campo 'Conta' não encontrado.");

                if (campos.TryGetValue("Histórico", out string hist))
                    lancamento.Historico = hist;
                else throw new Exception("Campo 'Histórico' não encontrado.");

                if (campos.TryGetValue("Valor", out string valorStr))
                    lancamento.Valor = decimal.Parse(valorStr, new CultureInfo("pt-BR"));
                else throw new Exception("Campo 'Valor' não encontrado.");

                if (campos.TryGetValue("Tipo", out string tipoStr))
                    lancamento.Tipo = tipoStr;
                else throw new Exception("Campo 'Tipo' não encontrado.");

                LancamentoContabil l = new()
                {
                    Data = DateTime.Parse(dataStr),
                    Conta = int.Parse(contaStr),
                    Historico = hist,
                    Valor = decimal.Parse(valorStr),
                    Tipo = tipoStr,
                };

                bool dadosValidos =
                    lancamento.Data != default &&
                    lancamento.Conta > 0 &&
                    !string.IsNullOrWhiteSpace(lancamento.Historico) &&
                    !string.IsNullOrWhiteSpace(lancamento.Tipo) &&
                    lancamento.Valor > 0;

                if (dadosValidos)
                {
                    lancamentos.Add(l);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro logo antes da linha {i + 1} do arquivo de texto, favor corrigir esse bloco");
            }
        }

        return lancamentos;
    }
}


