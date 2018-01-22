using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLib.Entities;

namespace DataAccessLib
{
  namespace Entities
  {
    public class Book
    {
      public int BookID { get; set; }
      public string Title { get; set; }
      public double Price { get; set; }
    }

  }
  public interface IDataComponent
  {
    void AddNewBook(Book book);
    void UpdateBook(Book book);
    List<Book> FindBooks(string title);

    List<string> GetAllTitles();
  }
  public class DataComponent : IDataComponent
  {
    public void AddNewBook(Book book)
    {
      var context = new NichiInDatabaseEntities();
      var bookTbl = new BookTable
      {
        BookId = book.BookID,
        Cost = Convert.ToDecimal(book.Price),
        Title = book.Title
      };
      context.BookTables.Add(bookTbl);
      context.SaveChanges();
    }

    public List<Book> FindBooks(string title)
    {
      var context = new NichiInDatabaseEntities();
      return context.BookTables.Select((b) => new Book {
        BookID = b.BookId, Title = b.Title, Price = Convert.ToDouble(b.Cost)
      }).ToList();
    }

    public List<string> GetAllTitles()
    {
      var context = new NichiInDatabaseEntities();
      return context.BookTables.Select((b) => b.Title).ToList();
    }

    public void UpdateBook(Book book)
    {
      var context = new NichiInDatabaseEntities();
      var bk = context.BookTables.FirstOrDefault((b) => b.BookId == book.BookID);
      bk.BookId = book.BookID;
      bk.Cost = Convert.ToDecimal(book.Price);
      bk.Title = book.Title;
      context.SaveChanges();
    }
  }
}
