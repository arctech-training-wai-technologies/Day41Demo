using System.Net;
using Day41Demo.DataAccess;
using Day41Demo.DataAccess.Models;

namespace Day41Demo.Services;

public class ProductService
{
    public List<ProductBrandCategoryInfo> GetAllBrandCategoryWiseProducts()
    {
        using var context = new SampleStoreContext();

        var productsQuery = from p in context.Products
                            join c in context.Categories on p.CategoryId equals c.CategoryId
                            join b in context.Brands on p.BrandId equals b.BrandId
                            select new ProductBrandCategoryInfo
                            {
                                ProductId = p.ProductId,
                                ProductName = p.ProductName,
                                BrandName = b.BrandName,
                                CategoryName = c.CategoryName
                            };

        var products = productsQuery.ToList();
        return products;
    }

    /// <summary>
    /// --Group By and Having example
    /// --Display all brand info with 
    /// --a. the cost of most expensive product
    /// --b. the cost of cheapest product
    /// --only for those brands having > 10 products
    /// --Brand_id, brand_name, Most_Expensive_Product_Cost, Cheapest_Product_Cost
    ///
    /// select
    /// 	b.brand_id, b.brand_name,
    /// 	max(p.list_price) as "Most Expensive Product Cost",
    /// 	min(p.list_price) as "Cheapest Product Cost"
    /// 	--,count(p.product_id) as Total_Products
    /// from
    /// 	production.products p
    /// inner join
    /// 	production.brands b
    /// on
    /// 	p.brand_id = b.brand_id
    /// group by
    /// 	b.brand_id, b.brand_name
    /// having
    /// 	count(p.product_id) > 10
    /// </summary>
    /// <returns></returns>
    public List<BrandInfoWithProductPriceInfo> GetBrandInfoWithProductPriceInfo()
    {
        using var context = new SampleStoreContext();

        var query =
        from p in context.Products
        join b in context.Brands on p.BrandId equals b.BrandId
        group new { p.ListPrice } by new { b.BrandId, b.BrandName } into groupedItems
        where groupedItems.Count() > 10
        select new BrandInfoWithProductPriceInfo
        {
            BrandId = groupedItems.Key.BrandId,
            BrandName = groupedItems.Key.BrandName,
            MostExpensive = groupedItems.Max(p => p.ListPrice),
            Cheapest = groupedItems.Min(p => p.ListPrice),
            TotalProducts = groupedItems.Count()
        };

        var brandInfos = query.ToList();

        return brandInfos;
    }

    // Category wise Average Price (avg) and Launch year (min)
    public List<CategoryWisePriceYearInfo> GetCategoryWisePriceYear()
    {
        using var context = new SampleStoreContext();

        var query =
            from c in context.Categories
            join p in context.Products on c.CategoryId equals p.CategoryId
            group new { p.ListPrice, p.ModelYear } by new { c.CategoryId, c.CategoryName } into groupedItems
            select new CategoryWisePriceYearInfo
            {
                CategoryId = groupedItems.Key.CategoryId,
                CategoryName = groupedItems.Key.CategoryName,
                AveragePrice = groupedItems.Average(p => p.ListPrice),
                LaunchYear = groupedItems.Min(p => p.ModelYear)
            };

        return query.ToList();
    }

}

// ViewModel / DTO

public class CategoryWisePriceYearInfo
{
    public int CategoryId { get; set; }
    public decimal AveragePrice { get; set; }
    public int LaunchYear { get; set; }
    public string CategoryName { get; set; }
}

public class ProductBrandCategoryInfo
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string CategoryName { get; set; }
    public string BrandName { get; set; }
}

public class BrandInfoWithProductPriceInfo
{
    public int BrandId { get; set; }
    public string BrandName { get; set; }
    public decimal MostExpensive { get; set; }
    public decimal Cheapest { get; set; }
    public int TotalProducts { get; set; }
}