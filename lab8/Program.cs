using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;

[Serializable]
class Item
{
    public string Name { get; set; }
    public int Quantity { get; set; }
}

class Program
{
    static void Main()
    {
        // Запрос пользователя на ввод данных.
        Console.Write("Введите количество предметов: ");
        int itemCount = int.Parse(Console.ReadLine());

        Item[] itemsToSave = new Item[itemCount];

        for (int i = 0; i < itemCount; i++)
        {
            Console.WriteLine($"Введите данные для предмета {i + 1}:");
            Console.Write("Имя предмета: ");
            string name = Console.ReadLine();

            Console.Write("Количество: ");
            int quantity = int.Parse(Console.ReadLine());

            itemsToSave[i] = new Item { Name = name, Quantity = quantity };
        }

        // Использование универсального класса для сохранения и загрузки данных.
        DataHandler<Item[]> dataHandler = new DataHandler<Item[]>();

        // Сохранение в бинарном файле.
        dataHandler.SaveToBinaryFile(itemsToSave, "binary_data.dat");

        // Загрузка из бинарного файла.
        Item[] loadedItemsBinary = dataHandler.LoadFromBinaryFile("binary_data.dat");

        // Вывод результатов загрузки из бинарного файла.
        DisplayLoadedItems(loadedItemsBinary, "бинарном файле");

        // Сохранение в JSON файле.
        dataHandler.SaveToJsonFile(itemsToSave, "json_data.json");

        // Загрузка из JSON файла.
        Item[] loadedItemsJson = dataHandler.LoadFromJsonFile("json_data.json");

        // Вывод результатов загрузки из JSON файла.
        DisplayLoadedItems(loadedItemsJson, "JSON файле");
    }

    static void DisplayLoadedItems(Item[] loadedItems, string fileType)
    {
        // Вывод результатов загрузки.
        if (loadedItems != null)
        {
            Console.WriteLine($"\nДанные, восстановленные из {fileType}:");
            foreach (var item in loadedItems)
            {
                Console.WriteLine($"Name: {item.Name}, Quantity: {item.Quantity}");
            }
        }
    }
}