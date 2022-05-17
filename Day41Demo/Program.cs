// See https://aka.ms/new-console-template for more information

using Day41Demo.Services;

//Test1();
//Test2();
Test3();


void Test1()
{
    var productService = new ProductService();
    var productBrandCategoryInfos = productService.GetAllBrandCategoryWiseProducts();

    foreach (var info in productBrandCategoryInfos)
    {
        Console.WriteLine($"{info.BrandName} - {info.CategoryName} - {info.ProductId} - {info.ProductName}");
    }
}

void Test2()
{
    var productService = new ProductService();
    var brandInfoWithProductPriceInfos = productService.GetBrandInfoWithProductPriceInfo();

    foreach (var info in brandInfoWithProductPriceInfos)
    {
        Console.WriteLine($"{info.BrandId} - {info.BrandName,-20} - {info.MostExpensive, -10} - {info.Cheapest} - {info.TotalProducts, -10}");
    }
}

void Test3()
{
    var productService = new ProductService();;
    var categoryWisePriceYearInfos = productService.GetCategoryWisePriceYear();

    foreach (var info in categoryWisePriceYearInfos)
    {
        Console.WriteLine($"{info.CategoryId,-3}{info.CategoryName,-20}{info.AveragePrice,-15}{info.LaunchYear,-10}");
    }
}
