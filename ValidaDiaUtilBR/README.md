# 📅 ValidaDiaUtilBR

Uma biblioteca .NET para validação de dias úteis no Brasil, considerando finais de semana e feriados nacionais (fixos e móveis). Ideal para aplicações que precisam lidar com regras de calendário, como sistemas financeiros, fiscais ou de agendamento.

---

## ✨ Funcionalidades

- ✅ Verifica se uma data é um dia útil
- 📆 Identifica finais de semana
- 🎉 Reconhece feriados nacionais brasileiros (fixos e móveis)
- ➕ Permite adicionar feriados personalizados
- 🔁 Retorna o próximo ou anterior dia útil
- 📝 Informa a descrição do feriado, se houver

---

## 🚀 Instalação

Você pode adicionar esta biblioteca ao seu projeto via NuGet:

```bash
dotnet add package ValidaDiaUtilBR
```

## 🛠️ Como Usar

### Instanciando a classe

```
using ValidaDiaUtilBR;

// Para o ano atual
var validador = new ValidaDiaUtil();

// Para um ano específico
var validador2026 = new ValidaDiaUtil(2026);
```
### Verificar se uma data é dia útil

```
bool ehUtil = validador.EhDiaUtil(new DateTime(2025, 12, 25)); // false (Natal)
```
### Verificar se é final de semana

```
bool fimDeSemana = validador.EhFinalDeSemana(DateTime.Today);
```

### Verificar se é feriado

```
bool feriado = validador.EhFeriado(new DateTime(2025, 11, 15)); // true
```
### Obter descrição do feriado

```
string descricao = validador.DescricaoFeriado(new DateTime(2025, 11, 15)); // "Proclamação da República"
```

### Adicionar feriado personalizado

```
validador.AdicionarFeriado(new DateTime(2025, 6, 13), "Aniversário da Cidade");
```

### Encontrar o próximo dia útil

```
DateTime proximoUtil = validador.DiaUtilProximo(new DateTime(2025, 12, 25));
```

### Encontrar o dia útil anterior

```
DateTime anteriorUtil = validador.DiaUtilAnterior(new DateTime(2025, 1, 1));
```

## 📌 Feriados Considerados

#### A biblioteca considera os seguintes feriados nacionais:
| 📅 Data       | 🎉 Feriado                     | 📝 Observação                          |
|--------------|-------------------------------|----------------------------------------|
| 01/01        | Ano Novo                      | Feriado fixo                           |
| Variável     | Carnaval                      | 47 dias antes da Páscoa                |
| Variável     | Páscoa                        | Calculada via algoritmo Computus       |
| 21/04        | Tiradentes                    | Feriado fixo                           |
| 01/05        | Dia do Trabalho               | Feriado fixo                           |
| 07/09        | Independência do Brasil       | Feriado fixo                           |
| 12/10        | Nossa Senhora Aparecida       | Feriado fixo                           |
| 02/11        | Finados                       | Feriado fixo                           |
| 15/11        | Proclamação da República      | Feriado fixo                           |
| 20/11        | Consciência Negra             | Feriado fixo (em alguns estados)       |
| 25/12        | Natal                         | Feriado fixo                           | 

#### Você também pode adicionar feriados personalizados conforme a necessidade da sua aplicação.

## 📦 Contribuições
Contribuições são muito bem-vindas! Sinta-se à vontade para:
- Reportar bugs
- Sugerir melhorias
- Criar pull requests com novas funcionalidades ou feriados regionais

### 📄 Licença
Este projeto está licenciado sob a MIT License.