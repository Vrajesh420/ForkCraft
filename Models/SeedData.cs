using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ForkCraft.Data;
using System;
using System.Linq;

namespace ForkCraft.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ForkCraftContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ForkCraftContext>>()))
            {
                // Look for any movies.
                if (context.Fork.Any())
                {
                    return;   // DB has been seeded
                }

                context.Fork.AddRange(
                    new Fork
                    {
                        Type = "Dinner Fork",
                        Material = "Stainless Steel",
                        Finishing = "Polished",
                        HandleDesign = "Classic",
                        Size = "10cm",
                        Price = 17.99M
                    },

                    new Fork
                    {
                        Type = "Salad Fork",
                        Material = "Silver",
                        Finishing = "Dimmed",
                        HandleDesign = "Curved",
                        Size = "19cm",
                        Price = 20.99M
                    },

                    new Fork
                    {
                        Type = "Dessert Fork",
                        Material = "Wood",
                        Finishing = "Brushed",
                        HandleDesign = "Round",
                        Size = "15cm",
                        Price = 30.99M
                    },

                    new Fork
                    {
                        Type = "Fish Fork",
                        Material = "Plastic",
                        Finishing = "Mirror",
                        HandleDesign = "Angled",
                        Size = "18cm",
                        Price =20.99M
                    },
                    new Fork
                    {
                        Type = "Cocktail Fork",
                        Material = "Stainless Steel",
                        Finishing = "Stain",
                        HandleDesign = "Classic",
                        Size = "11cm",
                        Price = 45.99M
                    },
                    new Fork
                    {
                        Type = "Oyster Fork",
                        Material = "Ceramic",
                        Finishing = "Mirror",
                        HandleDesign = "Angled",
                        Size = "17cm",
                        Price = 65.99M
                    },
                    new Fork
                    {
                        Type = "Pastry Fork",
                        Material = "Stainless Steel",
                        Finishing = "PVD",
                        HandleDesign = "Round",
                        Size = "10cm",
                        Price = 4.99M
                    },
                    new Fork
                    {
                        Type = "Fruit Fork",
                        Material = "Wood",
                        Finishing = "Brushed",
                        HandleDesign = "Classic",
                        Size = "14cm",
                        Price = 82.99M
                    },
                    new Fork
                    {
                        Type = "Cheese Fork",
                        Material = "Sliver",
                        Finishing = "Polished",
                        HandleDesign = "Angled",
                        Size = "20cm",
                        Price = 47.99M
                    },
                    new Fork
                    {
                        Type = "Escargot Fork",
                        Material = "Golden",
                        Finishing = "Dimmed",
                        HandleDesign = "Curved",
                        Size = "16cm",
                        Price = 77.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
