namespace Repository
{
    // Produktmodellen representerar en produkt i webbshoppen
    public class Product
    {
        public int Id { get; set; } // Unikt ID för produkten
        public string Name { get; set; } // Namn på produkten
        public int Stock { get; set; } // Quantity available in stock

    }
}