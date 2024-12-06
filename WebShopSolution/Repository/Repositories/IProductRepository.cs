﻿namespace Repository
{
    // Gränssnitt för produktrepositoryt enligt Repository Pattern
    public interface IProductRepository : IRepository<Product> 
    {

        //vi kan nu ta bort metoderna eftersom att de redan finns i basklassen och implementeras direkt genom arv
        //genom att skicka in typen specifierar vi obj typ vi vill utföra operationer på

        //vi kan utöka specifika metoder bara för product obj som exv produktsaldo
        bool UpdateStock(Product product, int q);
    }
}
