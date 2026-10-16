using System;
using System.Collections.Generic;
using System.Text;
using Bunit;
using FullStackDevWeek5.Components;
using FullStackDevWeek5.Components.Pages;
using FullStackDevWeek5.Models;
using Microsoft.AspNetCore.Components;


namespace FullStackDevWeek5Test
{
    public class ProductListTest : TestContext
    {

        //[Fact]
        //public void ProductList_ShouldShowEmptyMessage_WhenNoProductsProvided()
        //{
        //    // Arrange
        //    // (No products provided, defaults to empty list)

        //    // Act - Render the component
        //    var cut = Render<ProductList>();

        //    // Assert - Verify the "No products found" text is rendered
        //    cut.Find("p").MarkupMatches("<p><em></em></p>");
        //}


        //[Fact]
        //public void ProductList_ShouldRenderProducts_WhenListIsPopulated()
        //{
        //    // Arrange - Create sample data
        //    var sampleProducts = new List<Product>
        //    {
        //        new() { Name = "Laptop", Price = 999.99m },
        //        new() { Name = "Mouse", Price = 25.50m }
        //    };

        //    // Act - Render with parameters
        //    var cut = Render<ProductList>(parameters => parameters
        //        .Add(p => p.products, sampleProducts)
        //    );

        //    // Assert 1: Check that the correct number of rows rendered
        //    var rows = cut.FindAll(".product-row");
        //    Assert.Equal(2, rows.Count);

        //    // Assert 2: Verify specific content exists in the markup
        //    Assert.Contains("Laptop", cut.Markup);
        //    Assert.Contains("Mouse", cut.Markup);
        //}


        [Fact]
        public void Counter_Increments()
        {
            // Arrange
            var ctx = new TestContext();
            var comp = ctx.Render<Counter>();
            // Act
            comp.Find("button").Click();
            // Assert
            comp.Markup.Contains("1");
        }



    }
}
