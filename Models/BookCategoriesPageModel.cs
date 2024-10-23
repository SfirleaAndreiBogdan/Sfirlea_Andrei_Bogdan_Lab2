﻿using Microsoft.AspNetCore.Mvc.RazorPages;
using Sfirlea_Andrei_Bogdan_Lab2.Data;


namespace Sfirlea_Andrei_Bogdan_Lab2.Models
{
    public class BookCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList = new List<AssignedCategoryData>();

        public void PopulateAssignedCategoryData(Sfirlea_Andrei_Bogdan_Lab2Context context,Book book)
        {
            var allCategories = context.Category;
            var bookCategories = new HashSet<int>(
            book.BookCategories.Select(c => c.CategoryID)); //
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.Id,
                    Name = cat.CategoryName,
                    Assigned = bookCategories.Contains(cat.Id)
                });
            }
        }
        public void UpdateBookCategories(Sfirlea_Andrei_Bogdan_Lab2Context context, string[] selectedCategories, Book bookToUpdate)
        {
            if (selectedCategories == null)
            {
                bookToUpdate.BookCategories = new List<BookCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var bookCategories = new HashSet<int>
            (bookToUpdate.BookCategories.Select(c => c.Category.Id));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.Id.ToString()))
                {
                    if (!bookCategories.Contains(cat.Id))
                    {
                        bookToUpdate.BookCategories.Add(
                        new BookCategory
                        {
                            BookID = bookToUpdate.ID,
                            CategoryID = cat.Id
                        });
                    }
                }
                else
                {
                    if (bookCategories.Contains(cat.Id))
                    {
                        BookCategory bookToRemove
                        = bookToUpdate
                        .BookCategories
                       .SingleOrDefault(i => i.CategoryID == cat.Id);
                        context.Remove(bookToRemove);
                    }
                }
            }
        }
    }
}