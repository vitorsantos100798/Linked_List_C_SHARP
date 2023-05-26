void Insere(ref tp_no t, string name, string age, string zap)
{
  tp_no no = new tp_no();
  no.nome = name;
  no.idade = age;
  no.whats = zap;
  if (t != null)
    no.prox = t;
  t = no;
}

void Consulta(tp_no l, string nomeproc, ref tp_no atua, ref tp_no ant)
{
  atua = l;
  ant = l;

  while (atua != null && nomeproc != atua.nome)
  {
    ant = atua;
    atua = atua.prox;
  }
}

void Alterar(tp_no lista)
{
  if (lista == null)
  {
    Console.WriteLine("Não tem ninguém cadastrado!");
  }
  else
  {
    Console.WriteLine();
    tp_no anterior = null;
    tp_no atual = null;

    Console.WriteLine("Informe o nome que deseja procurar: ");
    Console.Write("Busca: ");
    string nome_procurado = Console.ReadLine();

    Consulta(lista, nome_procurado, ref anterior, ref atual);
    Console.WriteLine("Dados atuais.");
    Console.WriteLine("Nome: " + atual.nome);
    Console.WriteLine("Idade: " + atual.idade);
    Console.WriteLine("Whats: " + atual.whats);
    Console.WriteLine();
    Console.WriteLine("Alterar Nome:");
    atual.nome = Console.ReadLine();

    Console.WriteLine("Alterar idade:");
    atual.idade = Console.ReadLine();

    Console.WriteLine("Alterar whats:");
    atual.whats = Console.ReadLine();
  }
}

void Exibir(tp_no lista)
{
  tp_no auxiliar = lista;
  while (auxiliar != null)
  {
    Console.WriteLine("Nome: " + auxiliar.nome);
    Console.WriteLine("Idade: " + auxiliar.idade);
    Console.WriteLine("Whats: " + auxiliar.idade);
    Console.WriteLine();
    auxiliar = auxiliar.prox;
  }
}

tp_no lista = null;
int op = 0;
string nome, idade, whats;
tp_no anterior = null, atual = null;

while (op != 5)
{
  Console.WriteLine("\n[1] - Inserir Dados");
  Console.WriteLine("[2] - Consultar e Alterar Dados");
  Console.WriteLine("[3] - Excluir Dados");
  Console.WriteLine("[4] - Exibir Dados Cadastrados");
  Console.WriteLine("[5] - Sair");

  Console.Write("\nDigite a opção desejada: ");

  op = Convert.ToInt32(Console.ReadLine());

  if (op == 1)
  {
    Console.Write("Digite seu nome: ");
    nome = Console.ReadLine();

    Console.Write("Digite sua idade: ");
    idade = Console.ReadLine();

    Console.Write("Digite seu número: ");
    whats = Console.ReadLine();

    Insere(ref lista, nome, idade, whats);
  }

  else if (op == 2)
  {
    Console.Write("Digite o nome que deseja alterar: ");
    nome = Console.ReadLine();
    Consulta(lista, nome, ref atual, ref anterior);

    if (atual != null)
    {
      Console.WriteLine("\nDados atuais");
      Console.WriteLine("Nome: " + atual.nome);
      Console.WriteLine("Idade: " + atual.idade);
      Console.WriteLine("Whats: " + atual.whats);

      Console.WriteLine();

      Console.WriteLine("Digite os novos dados\n");
      Console.Write("Nome: ");
      atual.nome = Console.ReadLine();
      Console.Write("Idade: ");
      atual.idade = Console.ReadLine();
      Console.Write("Whats: ");
      atual.whats = Console.ReadLine();
    }
    else
    {
      Console.WriteLine("Nome não encontrado.");
    }
  }

  else if (op == 3)
  {
    Console.WriteLine("Excluir elementos na lista.");
    if (lista == null)
    {
      Console.WriteLine("Não tem ninguem cadastrado!");
    }

    else
    {
      Console.Write("Informe o nome que deseja procurar: ");
      string nome_procurado = Console.ReadLine();
      Consulta(lista, nome_procurado, ref atual, ref anterior);
      Console.WriteLine();
      Console.WriteLine("Dados Excluidos.");
      Console.WriteLine("Nome: " + atual.nome);
      Console.WriteLine("Idade: " + atual.idade);
      Console.WriteLine("Whats: " + atual.whats);

      // Começo da lista
      if (anterior == null)
      {
        lista = atual.prox;
        atual.prox = null;
      }

      // Final da lista
      if (atual.prox == null)
      {
        anterior.prox = null;
      }

      // Meio da lista
      else
      {
        anterior.prox = atual.prox;
        atual.prox = null;
      }
    }
  }

  else if (op == 4)
  {
    if (lista != null)
    {
      Console.WriteLine("Exibir todos os elementos.");
      Exibir(lista);
    }

    else
    {
      Console.WriteLine("Não existe registros!");
    }
  }
}

class tp_no
{
  public string nome, idade, whats;
  public tp_no prox;
}