namespace Aula19;

using System.ComponentModel.Design;
using System.IO;

public class Program
{
    public static void Main()
    {
        string path = @"C:\Users\ginac\source\repos\Aula19\";
        string fileName = "Lista_de_compras.txt";
        string filePath = path + fileName;
        //Assim ficará salvo na pasta documentos de qualquer usuário
        //string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);


        List<string> listaDeCompras = new List<string>();

        //Lógica
        if (File.Exists(filePath))
        {
            listaDeCompras.AddRange(File.ReadAllLines(filePath));  //Para me mostrar o arquivo caso ele exista já 
        }

        while (true)
        {
            Console.WriteLine("\n===== Lista de Compras =====");
            Console.WriteLine("1. Adicionar um item");
            Console.WriteLine("2. Remover item");
            Console.WriteLine("3. Exibir lista");
            Console.WriteLine("4. Limpar a lista");
            Console.WriteLine("5. Sair");
            Console.WriteLine("6. Excluir lista");
            Console.WriteLine("Digite a sua escolha: ");

            string? userChoice = Console.ReadLine();

            if (string.IsNullOrEmpty(userChoice))
            {
                Console.WriteLine("Entrada inválida. Tente novamente");
            }
            else
            {

                switch (userChoice)
                {
                    case "1":
                        Console.WriteLine("Digite o nome do item para adicionar a lista: ");
                        string? itemInsert = Console.ReadLine()?.Trim();

                        if (string.IsNullOrEmpty(itemInsert))
                        {
                            Console.WriteLine("O item não pode ser vazio.");
                        }
                        else
                        {
                            listaDeCompras.Add(itemInsert);
                            Console.WriteLine("O item foi adicionado!");
                        }

                        break;

                    case "2":
                        Console.WriteLine("Digite o nome do item para remover: ");
                        string? itemRemove = Console.ReadLine();

                        if (!string.IsNullOrEmpty(itemRemove))
                        {
                            if (listaDeCompras.Remove(itemRemove))
                            {
                                Console.WriteLine($"Item {itemRemove} foi removido com sucesso!");
                            }
                            else
                            {
                                Console.WriteLine("Item não encontrado");
                            }
                        }
                        else
                        {
                            Console.WriteLine("O item não pode ser vazio.");
                        }

                        break;

                    case "3":
                        Console.WriteLine("\nItens na sua lista de compras: ");

                        if (listaDeCompras.Count == 0)
                        {
                            Console.WriteLine("Não há itens na sua lista.");
                        }
                        else
                        {
                            for (int i = 0; i < listaDeCompras.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {listaDeCompras[i]}");
                            }
                        }

                        break;

                    case "4":
                        Console.WriteLine("Tem certeza que deseja limpar toda a lista? (S/N)");
                        string? userAnswer = Console.ReadLine()?.ToUpper();

                        if (!string.IsNullOrEmpty(userAnswer))
                        {
                            if (userAnswer == "S")
                            {
                                listaDeCompras.Clear();
                                File.WriteAllLines(filePath, listaDeCompras);
                                Console.WriteLine("A lista de compras foi limpa com sucesso!");
                            }
                            else
                            {
                                Console.WriteLine("Ação cancelada. A lista não foi alterada.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Entrada inválida. Tente novamente");
                        }

                        break;

                    case "5":
                        Console.WriteLine($"Saindo... Obrigada por utilizar a nossa lista de compras! \nDeseja salvar a sua lista? (S/N)");
                        string? userAnswerSave = Console.ReadLine()?.ToUpper();

                        if (!string.IsNullOrEmpty(userAnswerSave))
                        {
                            if (userAnswerSave == "S")
                            {
                                File.WriteAllLines(filePath, listaDeCompras);
                                Console.WriteLine($"Sua lista foi salva em {filePath} \nSaindo...");
                            }
                            else
                            {
                                Console.WriteLine("Saindo...");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Entrada inválida. Tente novamente.");
                        }

                        return;

                    case "6":
                        Console.WriteLine("Tem certeza que deseja excluir a lista? (S/N)");
                        string? userAnswerRemove = Console.ReadLine()?.ToUpper();

                        if (!string.IsNullOrEmpty(userAnswerRemove))
                        {
                            if (userAnswerRemove == "S")
                            {
                                if (File.Exists(filePath))
                                {
                                    File.Delete(filePath);
                                    listaDeCompras.Clear();
                                    Console.WriteLine("A lista foi excluída com sucesso!");
                                }
                                else
                                {
                                    Console.WriteLine("Nenhum arquivo foi encontrado para excluir.");
                                }

                            }
                            else
                            {
                                Console.WriteLine("Ação cancelada. A lista não foi alterada.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Entrada inválida. Tente novamente.");
                        }

                        break;

                    default:
                        Console.WriteLine("Essa opção é inválida. Tente novamente!");

                        break;

                }
            }
        }

    }
}